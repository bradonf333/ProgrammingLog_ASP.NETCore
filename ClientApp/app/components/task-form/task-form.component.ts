import { TaskService } from './../../service/task.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {

  pageTitle: string = "Create a new Programming Task";
  languages: any[];

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
        console.log("Languages", this.languages);
      })
  }

}
