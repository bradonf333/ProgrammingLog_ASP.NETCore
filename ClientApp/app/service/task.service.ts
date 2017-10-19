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

  getTasks() {
    return this.http.get(this.taskUrl)
      .map(res => res.json());
  }

  getLanguageById() {
    return this.http.get(this.langIdUrl)
      .map(res => res.json());
  }
  
}
