import { TaskService } from './../../service/task.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  pageTitle: string = "Tasks";
  tasks: any[];

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    

    this.taskService.getTasks()
    .subscribe(tasks => {
      this.tasks = tasks;
      console.log("Tasks", this.tasks);
    });

  }

}
