import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
}) 
export class AuthService {

  constructor() { }

  login(request: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(
      environment.apiBaseUrl + '/api/auth/login',
      {
        email: request.email,
        password: request.password,
      }
    );
  }
}
