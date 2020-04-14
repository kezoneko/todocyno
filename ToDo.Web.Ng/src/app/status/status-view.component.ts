import { Component, Input } from '@angular/core';

import { Status, StatusDisplay } from './status.model';

@Component({
    selector: 'app-status-view',
    templateUrl: './status-view.component.html'
})

export class StatusViewComponent {
    constructor() { }

    StatusDisplay = StatusDisplay;

    @Input()
    value: Status;
}
