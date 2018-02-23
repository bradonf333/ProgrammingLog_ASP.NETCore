import { Component, OnInit } from '@angular/core';
import { TaskService } from "../../service/task.service";
import { Router, ActivatedRoute } from '@angular/router'
import { ProgrammingTask } from "../app/models/task";
import { SaveProgrammingTask } from "../app/models/saveTask";
import { KeyValuePair } from "../app/models/keyValuePair";

@Component({
  selector: 'app-task-view',
  templateUrl: './task-view.component.html',
  styleUrls: ['./task-view.component.css']
})
export class TaskViewComponent implements OnInit {

  taskId: number;
  languages: KeyValuePair[];
  task: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private taskService: TaskService) {

      route.params.subscribe(p => {
        this.taskId = +p['id'];
        if (isNaN(this.taskId) || this.taskId <= 0) {
          router.navigate(['/tasks']);
          return;
        }
      });
  }

  ngOnInit() {

    //  --Note that this doesnt get the languages property... Probably because i am not setting it in the setTask method below??
    // this.taskService.getTask(id)
    //   .subscribe(task => {
    //     this.setTask(task);
    //   });
    this.taskService.getTask(this.taskId)
      .subscribe(
        t => this.task = t,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/tasks']);
            return;
          }
        });

      // this.taskService.getLanguages()
      // .subscribe(languages => {
      //   this.languages = languages;
      // });
  }

  delete() {
    if (confirm("Are you sure?")) {
      this.taskService.deleteTask(this.task.id)
        .subscribe(t => {
          this.router.navigate(['/tasks']);
        });
    }
  }
}
