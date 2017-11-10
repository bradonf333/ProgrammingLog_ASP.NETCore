import { PlatformState } from '@angular/platform-server';
import { TaskService } from './../../service/task.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {

  pageTitle: string = "Create a new Programming Task";
  languages: any[];
  task: any = {
    programmingLanguages: []
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private taskService: TaskService
  ) {
    route.params.subscribe(p => {
      this.task.id = +p['id'];
    })
  }

  ngOnInit() {

    var sources = [
      this.taskService.getLanguages()
    ];

    if (this.task.id) {
      sources.push(this.taskService.getTask(this.task.id));
    }

    Observable.forkJoin(sources).subscribe(data => {
      if (this.task.id) {
        this.task = data[0];
      }
      this.languages = data[1];
    });

    this.taskService.getTask(this.task.id)
      .subscribe(t => {
        this.task = t;
      });

    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
        console.log("Languages", this.languages);
      });
  }

  onLanguageToggle(langId: number, $event: any) {
    if ($event.target.checked) {
      this.task.programmingLanguages.push(langId);
    }
    else {
      var index = this.task.programmingLanguages.indexOf(langId);
      this.task.programmingLanguages.splice(index, 1);
    }
  }

  submit() {
    this.taskService.createTask(this.task)
      .subscribe(t => console.log(t));
  }

}
