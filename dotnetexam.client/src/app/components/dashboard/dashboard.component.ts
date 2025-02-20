import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CartService } from '../../services/cart.service';
import { Articulo } from '../../models/articulo.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  imports: [CommonModule, FormsModule,RouterModule], 
})
export class DashboardComponent implements OnInit {
  usuario: any = null;
  articulos: Articulo[] = [];

  constructor(private authService: AuthService,
    private router: Router,
    private http: HttpClient,
    private cartService: CartService) { }

  ngOnInit(): void {
    this.usuario = {
      nombre: 'Usuario de Prueba', 
      email: 'usuario@example.com'
    };
    this.http.get<Articulo[]>('https://localhost:7007/api/articulo')
      .subscribe((data) => {
        this.articulos = data; 
      });
  }
  addToCart(articulo: Articulo): void {
    this.cartService.addToCart(articulo); 
    alert(`${articulo.Descripcion} agregado al carrito`);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
