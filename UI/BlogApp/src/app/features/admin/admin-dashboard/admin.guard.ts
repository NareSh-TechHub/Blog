import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

@Injectable({ providedIn: 'root' })
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean | UrlTree {
    const user = this.authService.getUser();
    const isAdmin = user?.roles.some(role =>
      role.toLowerCase() === 'admin' || role.toLowerCase() === 'superadmin'
    );

    if (isAdmin) {
      return true;
    }

    return this.router.parseUrl(user ? '/' : '/login');
  }
}
