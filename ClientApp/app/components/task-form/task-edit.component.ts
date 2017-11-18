import * as _ from 'underscore';
import { KeyValuePair } from './../app/models/keyValuePair';
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

  mainTask: ProgrammingTask = {
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
    // route.params.subscribe(t => {
    //   this.task.id = +t['id'];
    // });
  }

  ngOnInit() {

    let id = +this.route.snapshot.params['id'];
    this.pageTitle += `: ${id}`;
    this.mainTask.id = id;

    //  --Note that this doesnt get the languages property... Probably because i am not setting it in the setTask method below??
    this.taskService.getTask(id)
      .subscribe(task => {
        this.setTask(task);
      });

    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
        console.log("Languages", this.languages);
      });
  }

  /**
   * Pass in a SaveProgramminTask and map to a ProgrammingTask.
   * Main objective is to take the KeyValuePairs of SaveProgrammingTask.Languages 
   * and map just the Id values to the ProgrammingTask.Languages array.
   * @param t 
   */
  setTask(saveTask: SaveProgrammingTask) {
    this.mainTask.description = saveTask.description;
    this.mainTask.hours = saveTask.hours;
    this.mainTask.summary = saveTask.summary;
    this.mainTask.taskDate = saveTask.taskDate;
    this.mainTask.programmingLanguages = saveTask.languages.map(({ id }) => id);
  }

  onLanguageToggle(langId: number, $event: any) {
    if ($event.target.checked) {
      this.mainTask.programmingLanguages.push(langId);
    }
    else {
      var index = this.mainTask.programmingLanguages.indexOf(langId);
      this.mainTask.programmingLanguages.splice(index, 1);
    }
  }

  submit() {
    this.taskService.updateTask(this.mainTask)
      .subscribe(t => alert("The Task has been successfully updated!"));
  }
}

