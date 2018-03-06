import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PhotoService {

  constructor(private http: Http) { }

  upload(taskId: number, photo: File) {
    var formData = new FormData;
    formData.append('file', photo);

    return this.http.post(`/api/tasks/${taskId}/photos`, formData)
      .map(res => res.json());
  }

  getPhotos(taskId: number) {
    return this.http.get(`/api/tasks/${taskId}/photos`)
      .map(res => res.json());
  }

}
