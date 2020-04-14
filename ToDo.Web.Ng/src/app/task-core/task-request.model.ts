import { TaskFilter } from './task-filter.model';
import { OrderDirection } from '../core/models/order-direction.model';
import { Status } from '../status/status.model';

export class GetTasks {
    pageIndex?: number;
    pageSize?: number;
    filter?: TaskFilter;
    orderBy?: string;
    orderDirection?: OrderDirection;
}

export class GetTask {
    id: number;
}

export class UpdateTask {
    id: number;
    title: string;
    status: Status;
}

export class CreateTask {
    title: string;
    status: Status;
}

export class DeleteTask {
    id: number;
}
