export enum Status {
    Done = 1,
    Undone = 0,
    InProcess = 2
}

const StatusDisplay: { [index: number]: string } = {};
StatusDisplay[Status.Done] = 'Done';
StatusDisplay[Status.Undone] = 'Undone';
StatusDisplay[Status.InProcess] = 'In Process';
export { StatusDisplay };
