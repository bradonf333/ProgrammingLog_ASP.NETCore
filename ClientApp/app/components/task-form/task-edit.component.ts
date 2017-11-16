import { TaskService } from './../../service/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ProgrammingTask } from './../app/models/task';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-edit',
  templateUrl: './task-edit.component.html',
  styleUrls: ['./task-edit.component.css']
})
export class TaskEditComponent implements OnInit {
  pageTitle: string = "Edit a Programming Task";
  languages: any[];
  task: ProgrammingTask = {
    id: 0,
    hours: '',
    description: '',
    summary: '',
    taskDate: '',
    programmingLanguages: []
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private taskService: TaskService) {
    route.params.subscribe(t => {
      this.task.id = + t['id'];
    })
  }

  ngOnInit() {
  }

}
