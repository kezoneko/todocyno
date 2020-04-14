import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ConfigService } from '../config/config.service';
import { CreatedEntity } from '../core/models/created-entity.model';
import { Page } from '../core/page.model';

import { Task } from './task.model';
import { GetTasks, GetTask, UpdateTask, CreateTask, DeleteTask } from './task-request.model';

@Injectable()
export class TaskService {
    private apiUrl = this.configService.config.apiBaseUrl + '/api';

    constructor(private httpClient: HttpClient, private configService: ConfigService) { }

    getTasks(getTasks: GetTasks): Observable<Page<Task>> {
        const url = `${this.apiUrl}/GetTasks`;
        return this.httpClient.post<Page<Task>>(url, getTasks);
    }

    getTask(getTask: GetTask): Observable<Task> {
        const url = `${this.apiUrl}/GetTask`;
        return this.httpClient.post<Task>(url, getTask);
    }

    updateTask(updateTask: UpdateTask): Observable<{}> {
        const url = `${this.apiUrl}/UpdateTask`;
        return this.httpClient.post(url, updateTask);
    }

    createTask(createTask: CreateTask): Observable<CreatedEntity<number>> {
        const url = `${this.apiUrl}/CreateTask`;
        return this.httpClient.post<CreatedEntity<number>>(url, createTask);
    }

    deleteTask(deleteTask: DeleteTask): Observable<{}> {
        const url = `${this.apiUrl}/DeleteTask`;
        return this.httpClient.post(url, deleteTask);
    }
}
