import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { LoginRequest } from '../models/login-request.model';
import { LoginResponse } from '../models/login-response.model';
import { RegisterRequest } from '../models/register-request.model';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private userSubject = new BehaviorSubject<LoginResponse | null>(null);
  user$ = this.userSubject.asObservable();

  constructor(private http: HttpClient) {
    const stored = localStorage.getItem('user');
    if (stored) this.userSubject.next(JSON.parse(stored));
  }

  login(request: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${environment.apiBaseUrl}/api/Auth/login`, request)
      .pipe(tap(res => {
        localStorage.setItem('user', JSON.stringify(res));
        this.userSubject.next(res);
      }));
  }

  register(request: RegisterRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Auth/register`, request);
  }

  logout(): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Auth/logout`, {})
      .pipe(tap(() => {
        localStorage.removeItem('user');
        this.userSubject.next(null);
      }));
  }

  getUser(): LoginResponse | null {
    return this.userSubject.value;
  }
}