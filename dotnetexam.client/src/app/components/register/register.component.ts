import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, FormsModule,RouterModule], 
})
export class RegisterComponent {
  nombre = '';
  email = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit(): void {
    this.authService.register(this.nombre, this.email, this.password).subscribe(
      () => {
        alert('Usuario registrado exitosamente');
        this.router.navigate(['/login']);
      },
      (error) => {
        alert('Error al registrar usuario');
      }
    );
  }
}