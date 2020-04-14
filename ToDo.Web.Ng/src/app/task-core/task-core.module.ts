import { NgModule } from '@angular/core';

import { CoreModule } from '../core/core.module';

import { TaskService } from './task.service';
import { TaskSelectComponent } from './task-select.component';
import { TaskShowComponent } from './task-show.component';

@NgModule({
    declarations: [
        TaskSelectComponent,
        TaskShowComponent
    ],
    imports: [
        CoreModule,
    ],
    providers: [
        TaskService
    ],
    exports: [
        TaskSelectComponent,
        TaskShowComponent
    ]
})
export class TaskCoreModule {

}
