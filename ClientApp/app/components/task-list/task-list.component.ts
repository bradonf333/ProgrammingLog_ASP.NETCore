import { SaveProgrammingTask } from './../app/models/saveTask';
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
  allTasks: SaveProgrammingTask[];
  filter: any = {};
  sort: string;
  reverseSort: boolean = false;
  languages: KeyValuePair[];

  constructor(private taskService: TaskService) { }

  ngOnInit() {

    this.populateTasks();

    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
      });
  }

  private populateTasks() {
    this.taskService.getTasks(this.filter)
      .subscribe(tasks => this.allTasks = tasks);
  }


  onLanguageFilterChange() {
    this.populateTasks();
  }

  onFilterChange() {
    this.populateTasks();
  }

  onTaskSummaryFilter() {
    this.populateTasks();
  }
}
