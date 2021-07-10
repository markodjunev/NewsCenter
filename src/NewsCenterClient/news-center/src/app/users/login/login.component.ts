import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm : FormGroup;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService) { 
      this.loginForm = this.fb.group( {
        'username': ['', [Validators.required]],
        'password': ['', [Validators.required, Validators.minLength(6)]]
      })
    }

  ngOnInit(): void {
  }

  login() {
    if (this.loginForm.invalid) {
      return;
    }
    
    this.toastrService.info('Logging in...')

    this.authService.login(this.loginForm.value).subscribe(data => {
      console.log(data);
      const userId = data.userId;
      const username = data.username;
      const token = data.token;
      const isAdmin = data.isAdmin;
      this.authService.setUserInfo(userId, username, token, isAdmin);
      this.toastrService.clear();
      this.toastrService.success("Logged in successfully!");
      this.router.navigate(["/"]);
    })
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
