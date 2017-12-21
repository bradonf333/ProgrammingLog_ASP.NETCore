import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class TaskService {

  private langUrl = '/api/languages';
  private taskUrl = '/api/tasks';
  private langIdUrl = '/api/languages/{id}';

  constructor(private http: Http) { }

  getLanguages() {
    return this.http.get(this.langUrl)
      .map(res => res.json());
  }

  getTasks(filter: any) {
    return this.http.get(this.taskUrl + '?' + this.toQueryString(filter))
      .map(res => res.json());
  }

  getTask(id: number) {
    return this.http.get(this.taskUrl + '/' + id)
      .map(res => res.json());
  }

  getLanguageById() {
    return this.http.get(this.langIdUrl)
      .map(res => res.json());
  }

  createTask(task: any) {
    return this.http.post(this.taskUrl, task)
      .map(res => res.json());
  }

  updateTask(task: any) {
    return this.http.put(this.taskUrl + '/' + task.id, task)
      .map(res => res.json);
  }

  deleteTask(id: number) {
    return this.http.delete(this.taskUrl + '/' + id)
      .map(res => res.json);
  }

  toQueryString(obj: any) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }

}
