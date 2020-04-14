import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CoreModule } from '../core/core.module';
import { TaskCoreModule } from '../task-core/task-core.module';
import { StatusModule } from '../status/status.module';

import { TaskListComponent } from './task-list.component';
import { TaskEditComponent } from './task-edit.component';
import { TaskViewComponent } from './task-view.component';

@NgModule({
    declarations: [
        TaskListComponent,
        TaskEditComponent,
        TaskViewComponent,
    ],
    imports: [
        RouterModule.forChild([
            { path: '', component: TaskListComponent },
            { path: ':id', component: TaskViewComponent }
        ]),
        CoreModule,
        StatusModule,
        TaskCoreModule
    ],
    providers: [
    ],
    entryComponents: [
        TaskEditComponent
    ]
})
export class TaskModule {

}
