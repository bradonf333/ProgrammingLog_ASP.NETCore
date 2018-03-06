# Programming Log Application

## About
This is an app using ASP.NET Core 2.0 and Angular.

## Purpose
I wanted to create this app for 2 reasons:
1. I wanted a way to track how much time I had spent programming.
    * This included actual time programming or any time spent to learning programming.
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