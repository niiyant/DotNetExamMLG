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
  cartItemCount: number = 0;

  constructor(private authService: AuthService,
    private router: Router,
    private http: HttpClient,
    private cartService: CartService) { }

  ngOnInit(): void {
    this.usuario = {
      nombre: 'Usuario de Prueba', 
      email: 'usuario@example.com'
    };
    this.http.get<any[]>('https://localhost:7007/api/articulo')
      .subscribe((data) => {
        // Mapear los datos para que coincidan con el modelo
        this.articulos = data.map(item => ({
          Id: item.id,
          Codigo: item.codigo,
          Descripcion: item.descripcion,
          Precio: item.precio,
          Imagen: item.imagen,
          Stock: item.stock
        }));
      });
      this.updateCartItemCount();

  }
  updateCartItemCount(): void {
    this.cartItemCount = this.cartService.getCartItems().length;
  }
  addToCart(articulo: Articulo): void {
    this.cartService.addToCart(articulo); 
    this.updateCartItemCount();
    alert(`${articulo.Descripcion} agregado al carrito`);
  }
  goToCart(): void {
    this.router.navigate(['/cart']);
  }
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
