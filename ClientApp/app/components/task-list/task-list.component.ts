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
  tasks: SaveProgrammingTask[];
  filterTasks: number[];
  filter: any = {};
  languages: KeyValuePair[];
  saveTask: SaveProgrammingTask;

  constructor(private taskService: TaskService) { }

  ngOnInit() {

    this.taskService.getTasks()
      .subscribe(tasks => {
        this.tasks = tasks;
      });

    this.taskService.getLanguages()
      .subscribe(languages => {
        this.languages = languages;
      });
  }

  onLanguageFilterChange() {

    var filteredTasks = this.tasks;
    var taskIds: number[] = [];

    for (let index = 0; index < this.tasks.length; index++) {
      const task = this.tasks[index];
      // console.log("Task: ", task);
      // console.log("Programming Languages: ", element.languages);
      for (let index2 = 0; index2 < task.languages.length; index2++) {

        // console.log("TaskLanguage ", task.languages[index2]);

        if (task.languages[index2].id == this.filter.languageId) {
          this.saveTask = task;
          // console.log(this.saveTask.id);

          // console.log("SaveTask: ", this.saveTask);
          
          /*
           ************************************************************************************************************
           * I am on to something here!!! I think I can add the entire task object to an array of tasks... 
           * I just need to initialize the task array first. Like i did above: var taskIds: number[] = [];
           ************************************************************************************************************
           */ 
          taskIds.push(this.saveTask.id);
          console.log(taskIds);
        }
        // console.log(task.languages[index]);
      }
    }
    // console.log("LanguageId: ", this.filter.languageId);
    // console.log("Task: ", this.tasks.filter(t => t.id === 181));

    // filteredTasks = filteredTasks.filter(t => t.languages.filter(l => l.id === this.filter.languageId));

    // filteredTasks = filteredTasks.filter(task => task.languages.length);


    // console.log(this.filterTasks);
  }

}
