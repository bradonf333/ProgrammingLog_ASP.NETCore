import { Query } from './../app/models/query';
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
  // queryResult: SaveProgrammingTask[];
  queryResult: any = {};
  query: Query = {
    sortBy: 'taskDate',
    isSortAscending: false,
    pageSize: 15,
    page: 1
  };
  filter: any = {};
  sort: string;
  reverseSort: boolean = false;
  languages: KeyValuePair[];
  columns = [
    { title: 'Id' },
    { title: 'Hours', key: 'taskHours', isSortable: true },
    { title: 'Language(s)' },
    { title: 'Task Summary', key: 'taskSummary', isSortable: true },
    { title: 'Task Date', key: 'taskDate', isSortable: true }
  ];

  constructor(private taskService: TaskService) { }

  ngOnInit() {

    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
      });

    this.populateTasks();
  }

  private populateTasks() {
    this.taskService.getTasks(this.query)
      .subscribe(tasks => this.queryResult = tasks);
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

  sortBy(columnName: any) {
    console.log(this.query);
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }

    this.populateTasks();
  }

  onPageChange(page: any) {
    this.query.page = page;
    this.populateTasks();
  }
}
