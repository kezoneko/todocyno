import { Status } from '../status/status.model';

export class Task {
    id: number;
    creationDate: Date;
    modificationDate: Date;
    creationUserId: number;
    modificationUserId: number;
    title: string;
    status: Status;
}
