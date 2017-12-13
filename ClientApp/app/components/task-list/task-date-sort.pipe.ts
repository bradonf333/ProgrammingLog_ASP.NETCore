import { Pipe, PipeTransform } from '@angular/core';
import { SaveProgrammingTask } from '../app/models/saveTask';

@Pipe({
  name: 'taskDateSort'
})
export class TaskDateSortPipe implements PipeTransform {
  /*
   * If this pipe works then I might as well see if i can just create a function that does the same thing.
   * Then when i click on the thead it calls the function.. .May similar to the filter function so its generic
   */
  transform(taskList: SaveProgrammingTask[], args?: any): any {

    if (!taskList || taskList === undefined || taskList.length === 0) {
      return null;
    }
    else {
      taskList.sort((task1: SaveProgrammingTask, task2: SaveProgrammingTask) => {
        if (task1.taskDate < task2.taskDate) {
          return 1;
        } else if (task1.taskDate > task2.taskDate) {
          return -1;
        } else {
          return 0
        }
      });
    }

    return taskList;
  }

}
