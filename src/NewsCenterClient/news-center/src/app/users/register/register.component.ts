import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService) {
      this.registerForm = this.fb.group({
        'username': ['', [Validators.required]],
        'firstName': ['', [Validators.required]],
        'lastName': ['', [Validators.required]],
        'email': ['', [Validators.required, Validators.email]],
        'password': ['', [Validators.required, Validators.minLength(6)]]
      })
  }

  ngOnInit(): void {
  }

  register() {
    if(this.registerForm.invalid) {
      return;
    }
    this.toastrService.info('Loading...')

    this.authService.register(this.registerForm.value).subscribe(data => {
      const userId = data.userId;
      const username = data.username;
      const token = data.token;
      const isAdmin = data.isAdmin;
      this.authService.setUserInfo(userId, username, token, isAdmin);
      this.toastrService.clear();
      this.toastrService.success("Registered successfully!");
      this.router.navigate(["/"]);
    })
  }

  get username() {
    return this.registerForm.get('username');
  }

  get firstName() {
    return this.registerForm.get('firstName');
  }

  get lastName() {
    return this.registerForm.get('lastName');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }
}
