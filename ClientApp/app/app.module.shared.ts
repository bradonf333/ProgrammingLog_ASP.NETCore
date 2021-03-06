import { AuthService } from './service/auth.service';
import { BrowserXhr } from '@angular/http';
import { ProgressService, BrowserXhrWithProgress } from './service/progress.service';
import { PhotoService } from './service/photo.service';
import { TaskService } from './service/task.service';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { TaskFormComponent } from './components/task-form/task-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { Ng2SearchPipeModule } from 'ng2-search-filter'; //importing the module

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TaskListComponent } from './components/task-list/task-list.component';
import { TaskEditComponent } from './components/task-form/task-edit.component';
import { TaskDateSortPipe } from './components/task-list/task-date-sort.pipe';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { TaskViewComponent } from './components/task-view/task-view.component';


@NgModule({
    declarations: [
        AppComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        TaskFormComponent,
        WelcomeComponent,
        TaskListComponent,
        TaskEditComponent,
        TaskDateSortPipe,
        PaginationComponent,
        TaskViewComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: 'welcome', component: WelcomeComponent},
            { path: '', redirectTo: 'welcome', pathMatch: 'full' },
            { path: 'tasks', component: TaskListComponent},
            { path: 'tasks/new', component: TaskFormComponent},           
            { path: 'tasks/:id', component: TaskEditComponent},           
            { path: 'taskView/:id', component: TaskViewComponent},           
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'welcome' }
        ]),
        Ng2SearchPipeModule
    ],
    providers: [
        { provide: BrowserXhr, useClass: BrowserXhrWithProgress },
        TaskService, PhotoService, ProgressService, AuthService
    ]
})
export class AppModuleShared {
}
