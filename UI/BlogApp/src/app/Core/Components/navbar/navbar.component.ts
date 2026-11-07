import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  user$ = this.authService.user$;
  userMenuOpen = false;

  constructor(private authService: AuthService, private router: Router) {}

  getDisplayName(email: string): string {
    const name = email.split('@')[0] || email;
    return name.charAt(0).toUpperCase() + name.slice(1);
  }

  getUserInitial(email: string): string {
    return this.getDisplayName(email).charAt(0);
  }

  isAdminUser(roles: string[]): boolean {
    return roles.some(role =>
      role.toLowerCase() === 'admin' || role.toLowerCase() === 'superadmin'
    );
  }

  onLogout(): void {
    this.userMenuOpen = false;
    this.authService.logout().subscribe({
      next: () => this.router.navigateByUrl('/')
    });
  }
}
