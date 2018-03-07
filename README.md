# Programming Log Application

## About
This is an app using ASP.NET Core 2.0 and Angular.

## Purpose
I wanted to create this app for 2 reasons:
1. I wanted a way to track how much time I had spent programming.
    * This included actual time programming or any time dedicated to learning new things in programming.
    Whether this was reading books, watching tutorials and following along, or building my own applications from scratch, anything like that.
2. This app serves as a programming diary. I can enter what I worked on that day, what worked, what didn't. I can note the progress I made or the troubles I had.
I can go back to any point in time and look to see what I worked on that day.


## Demos
### Main Index Page

App has a top nav bar and loads each page in the main section below.
![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/NavBarDemo.gif "Main Index")

---

### Pagination - Task List

Pagination done via the server. Breaks out the list of the Programming Tasks into separate pages. The logic for paging the tasks is done with ASP.NET Core and Entity Framework, rather than doing it on the Client-Side with Angular. The actual Pagination Component which displays the pagination info is done with Angular. When you've reached the end of the tasks you can't click the next button. Same applies when you are at the beginning of the list. You cannot go backwards in the pagination component.
![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/Pagination.gif "Task List - Pagination")

---

### Sorting - Task List
The list of Programming Tasks is defaulted to sort by the Task Date in DESC order. That way the newest tasks are displayed first. Sorting is done via the server, same as the Pagination. When clicking on a column header it sorts the list by that column and displays an arrow to indicate sorting desc or asc.
![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/Sorting.gif "Task List - Sorting")


---

### Language Filter - Task List
The Language filter drop down is populated by querying the available languages in the database. When one of the languages is selected in the dropdown the list of Tasks is filtered to only include those Tasks that have that language listed. This filtering is done on the server. Also notice that down below the total tasks count is updated to reflect the new count based on Tasks with the Language selected. Selecting no value in this dropdown defaults back to all Tasks.
![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/LanguageFilterDropDown.PNG "Task List - LanguageFilter PNG")

For some reason the drop down box didn't record so here is a screenshot.

![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/LangaugeFilter.gif "Task List - LanguageFilter")


---

### Summary Filter - Task List
The Summary filter is able to search the Task Summary using a text search. This filtering is also done on the server. Again the total tasks count is updated to reflect the new count based on filter.
![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/SummaryFilter.gif "Task List - SummaryFilter")


---

### Multiple Filters - Task List
The filtered list of tasks is used as the main context, so when multiple filters are applied the second filter does not reset the list, it filters based on the already filtered list. Also able to reset all filters with a button and return to the full list of tasks.
![alt text](https://github.com/bradonf333/ProgrammingLog_ASP.NETCore/blob/master/Demos/MultipleFilters.gif "Task List - MultipleFilters")
