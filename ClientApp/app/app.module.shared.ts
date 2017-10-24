import { TaskService } from './service/task.service';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { TaskFormComponent } from './components/task-form/task-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TaskListComponent } from './components/task-list/task-list.component';

@NgModule({
    declarations: [
        AppComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        TaskFormComponent,
        WelcomeComponent,
        TaskListComponent
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
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'welcome' }
        ])
    ],
    providers: [ TaskService ]
})
export class AppModuleShared {
}
