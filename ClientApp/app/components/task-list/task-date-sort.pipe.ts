import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'taskDateSort'
})
export class TaskDateSortPipe implements PipeTransform {
/*
 * If this pipe works then I might as well see if i can just create a function that does the same thing.
 * Then when i click on the thead it calls the function.. .May similar to the filter function so its generic
 */
  transform(value: any, args?: any): any {

    if(!value || value === undefined || value.length === 0) {
      return null;
    }
    else {
      value.sort((a: any, b: any ) => {
        if (a.taskDate < b.taskDate) {
          return 1;
        } else if (a.taskDate > b.taskDate){
          return -1;
        } else {
          return 0
        }
      });
    }

    return value;
  }

}
