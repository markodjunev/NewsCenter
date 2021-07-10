import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + 'account/login';
  private registerPath = environment.apiUrl + 'account/register';

  constructor(private http: HttpClient, private router: Router) {  }

  login(data: any): Observable<any> {
    return this.http.post(this.loginPath, data);
  }

  register(data: any): Observable<any> {
    return this.http.post(this.registerPath, data);
  }

  getUsername() {
    return localStorage.getItem('username');
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getIsAdmin(){
    return localStorage.getItem('isAdmin');
  }

  getUserId() {
    return localStorage.getItem('userId');
  }

  setUserInfo(userId: string, username: string, token: any, isAdmin: any) {
    localStorage.setItem('userId', userId);
    localStorage.setItem('username', username);
    localStorage.setItem('isAdmin', isAdmin);
    localStorage.setItem('token', token);
    return;
  }

  isAuthenticated(): boolean {
    if (this.getToken()) {
      return true;
    }
    return false;
  }

  isAdmin(): boolean {
    var isAdmin = this.getIsAdmin();
    if (isAdmin == 'true') {
      return true;
    }
    return false;
  }

  logout() {
    localStorage.clear();
    this.router.navigate(["login"]);
  }
}
