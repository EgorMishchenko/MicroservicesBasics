import { Component, OnInit } from '@angular/core';
import { LoginRequest } from '../models/login-request';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  model: LoginRequest;

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  onFormSubmit(): void {
    this.authService.login(this.model).subscribe({
      next: (response) => {
        console.log(response);

        this.authService.setUser({
          email: response.email,
          roles: response.roles,
        });

        this.router.navigateByUrl('/');
      },
    });
  }

}
