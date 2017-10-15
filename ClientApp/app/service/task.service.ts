import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class TaskService {

  private taskUrl = '/api/languages';

  constructor(private http: Http) { }

  getLanguages() {
    return this.http.get(this.taskUrl)
      .map(res => res.json());
  }

}
