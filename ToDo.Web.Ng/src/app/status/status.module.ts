import { NgModule } from '@angular/core';

import { CoreModule } from '../core/core.module';

import { StatusSelectComponent } from './status-select.component';
import { StatusViewComponent } from './status-view.component';

@NgModule({
    declarations: [
        StatusSelectComponent,
        StatusViewComponent
    ],
    imports: [
        CoreModule
    ],
    providers: [
    ],
    exports: [
        StatusSelectComponent,
        StatusViewComponent
    ]
})
export class StatusModule {

}
