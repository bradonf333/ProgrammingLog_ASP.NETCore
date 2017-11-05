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
  task: any = {
    languages: []
  };

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
        console.log("Languages", this.languages);
      });
  }

  onLanguageToggle(langId: number, $event: any) {
    if($event.target.checked) {
      this.task.languages.push(langId);
    }
    else {
      var index = this.task.languages.indexOf(langId);
      this.task.languages.splice(index, 1);
    }
  }

}
