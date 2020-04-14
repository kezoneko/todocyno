import { Component, Input } from '@angular/core';

import { Task } from './task.model';

@Component({
    selector: 'app-task-show',
    templateUrl: './task-show.component.html'
})

export class TaskShowComponent {
    @Input()
    value: Task;
}
