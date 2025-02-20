import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articulo } from '../../models/articulo.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-articulo-list',
  templateUrl: './articulo-list.component.html',
  styleUrls: ['./articulo-list.component.css'],
  imports: [CommonModule, FormsModule,RouterModule], 
})
export class ArticuloListComponent implements OnInit {
  articulos: Articulo[] = [];

  constructor(private http: HttpClient,private cartService: CartService) {}

  ngOnInit(): void {
    this.http.get<Articulo[]>('https://localhost:7007/api/articulo')
      .subscribe((data) => {
        this.articulos = data;
      });
  }
  addToCart(articulo: Articulo): void {
    this.cartService.addToCart(articulo); // Usa el servicio del carrito
    alert(`${articulo.Descripcion} agregado al carrito`);
  }
}