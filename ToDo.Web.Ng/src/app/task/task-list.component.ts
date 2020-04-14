import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { mergeMap } from 'rxjs/operators';

import { ModalHelper } from '../core/modal.helper';
import { StoreService } from '../core/store.service';
import { Error } from '../core/error.model';
import { Page } from '../core/page.model';
import { NoticeHelper } from '../core/notice.helper';

import { Task } from '../task-core/task.model';
import { TaskFilter } from '../task-core/task-filter.model';
import { TaskService } from '../task-core/task.service';
import { TaskEditComponent } from './task-edit.component';

class TaskListState {
    pageSize = 10;
    pageIndex = 0;
    filter = new TaskFilter();
}

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent implements OnInit {
    content: Page<Task>;
    state: TaskListState;
    pageSizeOptions = [10, 20];
    columns = [
        'title',
        'status',
        'action'
    ];

    constructor(
        private dialog: MatDialog,
        private modalHelper: ModalHelper,
        private taskService: TaskService,
        private storeService: StoreService,
        private noticeHelper: NoticeHelper
        ) {
        this.state = this.storeService.get('taskListState', new TaskListState());
    }

    ngOnInit() {
        this.getTasks();
    }

    private getTasks() {
        this.taskService.getTasks({
            pageIndex: this.state.pageIndex,
            pageSize: this.state.pageSize,
            filter: this.state.filter
        }).subscribe(content => this.content = content);
    }

    onSearch() {
        this.getTasks();
    }

    onReset() {
        this.state.filter.text = null;
        this.getTasks();
    }

    onCreate() {
        TaskEditComponent.show(this.dialog, 0).subscribe(() => {
            this.getTasks();
        });
    }

    onEdit(id: number) {
        TaskEditComponent.show(this.dialog, id).subscribe(() => {
            this.getTasks();
        });
    }

    onDelete(id: number) {
        this.modalHelper.confirmDelete()
            .pipe(
                mergeMap(() => this.taskService.deleteTask({ id }))
            )
            .subscribe(() => this.getTasks(),
                error => this.onError(error));
    }

    onPage(page: PageEvent) {
        this.state.pageIndex = page.pageIndex;
        this.state.pageSize = page.pageSize;
        this.getTasks();
    }

    onError(error: Error) {
        if (error) {
            this.noticeHelper.showError(error);
        }
    }
}
