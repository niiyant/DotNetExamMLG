export interface Articulo {
    Id: number; // ID único del artículo
    Codigo: string; // Código del artículo
    Descripcion: string; // Descripción del artículo
    Precio: number; // Precio del artículo
    Imagen: string; // URL de la imagen del artículo
    Stock: number; // Cantidad disponible en stock
  }