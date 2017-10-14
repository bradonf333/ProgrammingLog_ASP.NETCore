import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { TaskFormComponent } from './components/task-form/task-form.component';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ServerModule,
        AppModuleShared
    ],
    declarations: [TaskFormComponent]
})
export class AppModule {
}
