import { Component, OnInit } from '@angular/core';
import { LoginRequest } from '../models/login-request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  model: LoginRequest;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  onFormSubmit(): void {
    this.authService.login(this.model).subscribe({
      next: (response) => {
        console.log(response);

        this.cookieService.set(
          'Authorization',
          'Bearer ' + response.token,
          undefined,
          '/',
          undefined,
          true,
          'Strict'
        );

        this.authService.setUser({
          email: response.email,
          roles: response.roles,
        });

        this.router.navigateByUrl('/');
      },
    });
  }

}
