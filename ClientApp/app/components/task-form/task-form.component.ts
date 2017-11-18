import { ProgrammingTask } from './../app/models/task';
import { TaskService } from './../../service/task.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {

  pageTitle: string = "Create a new Programming Task";
  languages: any[];
  task: ProgrammingTask = {
    id: 0,
    hours: '',
    description: '',
    summary: '',
    taskDate: '',
    programmingLanguages: []
  };

  constructor(private taskService: TaskService) {  }

  ngOnInit() {
    
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
      .subscribe(t => alert("Successfully created task"));
  }

}
