import { EntityFilter } from '../core/models/entity-filter.model';
import { Status } from '../status/status.model';

export class TaskFilter extends EntityFilter {
    title?: string;
    status?: Status;
}
