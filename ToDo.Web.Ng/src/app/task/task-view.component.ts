import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

import { ConvertStringTo } from '../core/converter.helper';

import { Task } from '../task-core/task.model';
import { TaskService } from '../task-core/task.service';
import { TaskEditComponent } from './task-edit.component';

@Component({
    selector: 'app-task-view',
    templateUrl: './task-view.component.html',
    styleUrls: ['./task-view.component.scss']
})
export class TaskViewComponent implements OnInit {
    id: number;
    task: Task;

    constructor(private dialog: MatDialog,
                private taskService: TaskService,
                private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            this.id = ConvertStringTo.number(params.id);
            this.getTask();
        });
    }

    private getTask() {
        this.taskService.getTask({ id: this.id })
            .subscribe(task => this.task = task);
    }

    onEdit() {
        TaskEditComponent.show(this.dialog, this.id).subscribe(() => {
            this.getTask();
        });
    }

    onBack(): void {
        window.history.back();
    }
}
