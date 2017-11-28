import { TaskService } from './../../service/task.service';
import { Component, OnInit } from '@angular/core';
import { ProgrammingTask } from '../app/models/task';
import { KeyValuePair } from '../app/models/keyValuePair';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  pageTitle: string = "Tasks";
  tasks: ProgrammingTask[];
  filter: any = {};
  languages: KeyValuePair[];

  constructor(private taskService: TaskService) { }

  ngOnInit() {

    this.taskService.getTasks()
      .subscribe(tasks => {
        this.tasks = tasks;
      });

      this.taskService.getLanguages()
        .subscribe(languages => {
          this.languages = languages;
        });

  }

}
