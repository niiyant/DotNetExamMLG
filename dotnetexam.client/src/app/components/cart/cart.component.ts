import { Component } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { AuthService } from '../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Articulo } from '../../models/articulo.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  imports: [CommonModule, FormsModule,RouterModule], 
})
export class CartComponent {
  cartItems: Articulo[] = [];

  constructor(
    private cartService: CartService,
    private authService: AuthService,
    private http: HttpClient,private router: Router
  ) {
    this.cartItems = this.cartService.getCartItems();
  }

  removeFromCart(articuloId: number): void {
    this.cartService.removeFromCart(articuloId);
    this.cartItems = this.cartService.getCartItems();
  }

  checkout(): void {
    const clienteId = this.authService.getUserIdFromToken();
    const fecha = new Date();

    this.cartItems.forEach((item) => {
      this.http.post('https://localhost:7007/api/clientearticulo/comprar', {
        ClienteId: clienteId,
        ArticuloId: item.Id,
        Fecha: fecha
      }).subscribe(() => {
        alert('Compra realizada con éxito');
        this.cartService.clearCart(); 
        this.cartItems = [];
      });
    });
  }
  goToDashboard(): void {
    this.router.navigate(['/dashboard']);
  }
}