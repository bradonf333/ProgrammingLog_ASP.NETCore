import { KeyValuePair } from './../app/models/keyValuePair';
import * as _ from 'underscore';
import { TaskService } from './../../service/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ProgrammingTask } from './../app/models/task';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { SaveProgrammingTask } from '../app/models/saveTask';

@Component({
  selector: 'app-task-edit',
  templateUrl: './task-edit.component.html',
  styleUrls: ['./task-edit.component.css']
})
export class TaskEditComponent implements OnInit {
  pageTitle: string = "Edit a Programming Task";
  languages: KeyValuePair[];
  task: SaveProgrammingTask = {
    id: 0,
    hours: '',
    description: '',
    summary: '',
    taskDate: '',
    languages: []
  };
  taskLanguages: number[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private taskService: TaskService) {
    // route.params.subscribe(t => {
    //   this.task.id = +t['id'];
    // });
  }

  ngOnInit() {

    let id = +this.route.snapshot.params['id'];
    this.pageTitle += `: ${id}`;
    // this.task.id = id;

    //  --Note that this doesnt get the languages property... Probably because i am not setting it in the setTask method below??
    // this.taskService.getTask(id)
    //   .subscribe(task => {
    //     this.setTask(task);
    //   });

    //  --Note that this DOES get the languages property... Probably cause its just mapping the task from the getTask service.
    this.taskService.getTask(id)
      .subscribe(t => {
        this.task = t;
        this.getLanguageIds(this.task);
      });

    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
        console.log("Languages", this.languages);
      });
  }

  //
  // Trying to see if this can be passed a SaveTask rather than a regular task. Also need to see if i can make the programmingLanguages 
  // a key value pair on the SaveTask, then this would be similar to the vega app.
  //
  setTask(t: SaveProgrammingTask) {
    this.task.id = t.id;
    this.task.description = t.description;
    this.task.hours = t.hours;
    this.task.summary = t.summary;
    this.task.taskDate = t.taskDate;
    this.task.languages = t.languages;
  }

  getLanguageIds(t: SaveProgrammingTask) {
    this.taskLanguages = t.languages.map(({ id }) => id);
    // console.log("TaskLanguagesArray", this.taskLanguages);
  }

  /* Right now the task is a language, which is a key value pair. 
   * Maybe create a function that will grab the key value pair from the languages (maybe the service)
   * using the id that is given?
   * 
   * Maybe the reverse of the getLanguageIds function. Instead of mapping an id from the key value, map the key value from the id
   *
   */
  
  // onLanguageToggle(langId: number, $event: any) {
  //   if ($event.target.checked) {
  //     this.task.programmingLanguages.push(langId);
  //   }
  //   else {
  //     var index = this.task.programmingLanguages.indexOf(langId);
  //     this.task.programmingLanguages.splice(index, 1);
  //   }
  // }
}

