// import { SaveProgrammingTask } from './../app/models/saveTask';
// import { TaskService } from './../../service/task.service';
// import { Component, OnInit } from '@angular/core';
// import { ProgrammingTask } from '../app/models/task';
// import { KeyValuePair } from '../app/models/keyValuePair';

// @Component({
//   selector: 'app-task-list',
//   templateUrl: './task-list.component.html',
//   styleUrls: ['./task-list.component.css']
// })
// export class TaskListComponent implements OnInit {

//   pageTitle: string = "Tasks";
//   allTasks: SaveProgrammingTask[];
//   filteredTasks: SaveProgrammingTask[] = [];
//   filter: any = {};
//   sort: string;
//   reverseSort: boolean = false;
//   languages: KeyValuePair[];

//   constructor(private taskService: TaskService) { }

//   ngOnInit() {

//     this.taskService.getTasks()
//       .subscribe(tasks => {
//         this.allTasks = this.filteredTasks = tasks;
//       });

//     this.taskService.getLanguages()
//       .subscribe(languages => {
//         this.languages = languages;
//       });
//   }

//   /**
//    * Takes a string parameter and sorts the lists of tasks by the given string.
//    * @param sortBy 
//    */
//   onSort(sortBy: string) {

//     this.sort = sortBy;
//     var tasks = this.filteredTasks;

//     // Seems like there may be a better way to do this!

//     if (this.sort === "taskId") {
//       tasks = tasks.sort((task1: SaveProgrammingTask, task2: SaveProgrammingTask) => {
//         if (task1.id < task2.id) {
//           return -1;
//         } else if (task1.id > task2.id) {
//           return 1
//         } else {
//           return 0
//         }
//       });
//     }

//     if (this.sort === "taskHour") {
//       tasks = tasks.sort((task1: SaveProgrammingTask, task2: SaveProgrammingTask) => {
//         if (task1.hours < task2.hours) {
//           return -1;
//         } else if (task1.hours > task2.hours) {
//           return 1
//         } else {
//           return 0
//         }
//       });
//     }

//     if (this.sort === "taskLanguage") {
//       tasks = tasks.sort((task1: SaveProgrammingTask, task2: SaveProgrammingTask) => {
//         if (task1.languages < task2.languages) {
//           return -1;
//         } else if (task1.languages > task2.languages) {
//           return 1
//         } else {
//           return 0
//         }
//       });
//     }

//     if (this.sort === "taskSummary") {
//       tasks = tasks.sort((task1: SaveProgrammingTask, task2: SaveProgrammingTask) => {
//         if (task1.summary < task2.summary) {
//           return -1;
//         } else if (task1.summary > task2.summary) {
//           return 1
//         } else {
//           return 0
//         }
//       });
//     }

//     if (this.sort === "taskDate") {
//       tasks = tasks.sort((task1: SaveProgrammingTask, task2: SaveProgrammingTask) => {
//         if (task1.taskDate < task2.taskDate) {
//           return -1;
//         } else if (task1.taskDate > task2.taskDate) {
//           return 1
//         } else {
//           return 0
//         }
//       });
//     }

//     if (!this.reverseSort) {
//       this.filteredTasks = tasks;
//     } else {
//       this.filteredTasks = tasks.reverse();
//     }

//     this.reverseSort = !this.reverseSort;
//   }

//   onLanguageFilterChange() {

//     var tasks = this.allTasks;

//     /**
//      * If the TaskSummaryKeyWord Filter has a value we need to call that filter function to set the filtered list value
//      * based on that filter first.
//      * If it has no value then we just reset the filtered tasks to all tasks
//      */
//     if (this.filter.summaryKeyWord) {
//       this.onTaskSummaryFilter();
//       tasks = this.filteredTasks;
//     }
//     else {
//       tasks = this.allTasks;
//     }

//     if (this.filter.languageId) {
//       // Filter & some version of my nested for loops below!
//       this.filteredTasks = tasks.filter(
//         (task) => task.languages.some(
//           (language) => language.id == this.filter.languageId));

//       // This is a nested for loop version.... Much more work. Kinda keeping just so I can realize how much better the filter and some functions are

//       // Reset filteredTasks
//       // this.filteredTasks = [];

//       // for (let index = 0; index < tasks.length; index++) {
//       //   const task = tasks[index];

//       //   for (let index2 = 0; index2 < task.languages.length; index2++) {

//       //     if (task.languages[index2].id == this.filter.languageId) {
//       //       this.saveTask = task;
//       //       this.filteredTasks.push(this.saveTask);
//       //     }
//       //   }
//       // }
//     }
//     else if (this.filter.summaryKeyWord) {
//       this.onTaskSummaryFilter();
//       tasks = this.filteredTasks;
//     }
//     else {
//       this.filteredTasks = this.allTasks;
//     }
//   }

//   onTaskSummaryFilter() {

//     var tasks = this.allTasks;

//     if (this.filter.summaryKeyWord) {
//       this.filteredTasks = tasks.filter(
//         task => task.summary.toLocaleLowerCase().includes(this.filter.summaryKeyWord.toLocaleLowerCase())
//       );
//     }
//     else if (this.filter.languageId) {
//       this.onLanguageFilterChange();
//     }
//     else {
//       this.filteredTasks = this.allTasks;
//     }

//     // if (this.filter.languageId) {
//     //   this.onLanguageFilterChange();
//     //   tasks = this.filteredTasks;
//     // }
//     // else {
//     //   tasks = this.allTasks;
//     // }

//     // if (this.filter.summaryKeyWord) {
//     //   this.filteredTasks = tasks.filter(
//     //     task => task.summary.toLocaleLowerCase().includes(this.filter.summaryKeyWord.toLocaleLowerCase()));
//     // }
//     // else if (this.filter.languageId) {
//     //   this.onLanguageFilterChange();
//     //   tasks = this.filteredTasks;
//     // }
//     // else {
//     //   this.filteredTasks = this.allTasks;
//     // }

//   }

// }
