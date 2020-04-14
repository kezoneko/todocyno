import { Component, Input, OnInit, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { Observable, of } from 'rxjs';
import { filter } from 'rxjs/operators';

import { Error } from '../core/error.model';
import { NoticeHelper } from '../core/notice.helper';
import { ConvertStringTo } from '../core/converter.helper';

import { Task } from '../task-core/task.model';
import { TaskService } from '../task-core/task.service';

class DialogData {
    id: number;
}

@Component({
    selector: 'app-task-edit',
    templateUrl: './task-edit.component.html',
    styleUrls: ['./task-edit.component.scss']
})
export class TaskEditComponent implements OnInit {
    id: number;
    taskForm = this.fb.group({
        id: [],
        title: [],
        status: []
    });
    task: Task;
    error: Error;

    constructor(public dialogRef: MatDialogRef<TaskEditComponent>,
                @Inject(MAT_DIALOG_DATA) public data: DialogData,
                private taskService: TaskService,
                private fb: FormBuilder,
                private noticeHelper: NoticeHelper) {
        this.id = data.id;
    }

    static show(dialog: MatDialog, id: number): Observable<any> {
        const dialogRef = dialog.open(TaskEditComponent, {
            width: '600px',
            data: { id: id }
        });
        return dialogRef.afterClosed()
            .pipe(filter(res => res === true));
    }

    ngOnInit(): void {
        this.getTask();
    }

    private getTask() {
        const getTask$ = !this.id ?
            of(new Task()) :
            this.taskService.getTask({ id: this.id });
        getTask$.subscribe(task => {
            this.task = task;
            this.taskForm.patchValue(this.task);
        });
    }

    onSave(): void {
        this.saveTask();
    }

    private saveTask() {
        const saveTask$ = this.id ?
            this.taskService.updateTask(this.taskForm.value) :
            this.taskService.createTask(this.taskForm.value);
        saveTask$.subscribe(() => this.dialogRef.close(true),
            error => this.onError(error));
    }

    onError(error: Error) {
        this.error = error;
        if (error) {
            this.noticeHelper.showError(error);
            Error.setFormErrors(this.taskForm, error);
        }
    }
}
