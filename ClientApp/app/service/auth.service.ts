// src/app/auth/auth.service.ts

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operator/filter';
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthService {

    auth0 = new auth0.WebAuth({
        clientID: 'tkUgHkihmhsA1DHN71zSnoYa5bzm6qnc',
        domain: 'programminglogapp.auth0.com',
        responseType: 'token id_token',
        audience: 'https://programminglogapp.auth0.com/userinfo',
        redirectUri: 'http://localhost:51087/callback',
        scope: 'openid'
      });

    constructor(public router: Router) { }

    public login(): void {
        this.auth0.authorize();
    }

    public handleAuthentication(): void {
        this.auth0.parseHash((err, authResult) => {
            if (authResult && authResult.accessToken && authResult.idToken) {
                window.location.hash = '';
                this.setSession(authResult);
                this.router.navigate(['/tasks']);
                console.log("authResult", authResult);
            } else if (err) {
                this.router.navigate(['/tasks']);
                console.log(err);
            }
        });
    }


    private setSession(authResult: any): void {

        // Set the time that the Access Token will expire at
        const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
        localStorage.setItem('access_token', authResult.accessToken);
        localStorage.setItem('token', authResult.idToken);
        localStorage.setItem('id_token_payload', authResult.idTokenPayload['https://plog.com/roles']);
        localStorage.setItem('expires_at', expiresAt);

    }

    public logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
        // Go back to the home route
        this.router.navigate(['/tasks']);
    }

    public isAuthenticated(): boolean {

        // Check whether the current time is past the
        // Access Token's expiry time
        // const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
        const expiresAt = localStorage.getItem('expires_at');
        if (expiresAt) {
            return new Date().getTime().toString() < expiresAt;
        }
        else {
            return false;
        }

    }

}