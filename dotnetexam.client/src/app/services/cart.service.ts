import { Injectable } from '@angular/core';
import { Articulo } from '../models/articulo.model';


@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems: Articulo[] = [];

  // Agregar un artículo al carrito
  addToCart(articulo: Articulo): void {
    const item = this.cartItems.find((item) => item.Id === articulo.Id);
    if (item) {
      item.Stock++;
    } else {
      this.cartItems.push({ ...articulo, Stock: 1 }); 
    }
  }

  // Obtener todos los artículos del carrito
  getCartItems(): Articulo[] {
    return this.cartItems;
  }

  // Eliminar un artículo del carrito
  removeFromCart(articuloId: number): void {
    this.cartItems = this.cartItems.filter((item) => item.Id !== articuloId);
  }

  // Limpiar el carrito
  clearCart(): void {
    this.cartItems = [];
  }
}