import { AuthService } from './../../service/auth.service';
import { Component } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title: string = "Programming Tasks"

    constructor(private auth: AuthService) {
        auth.handleAuthentication();
    }
}
