namespace DotNetExam.Data.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        // Relación con Tiendas
        public ICollection<TiendaArticulo> Tiendas { get; set; }

        // Relación con Clientes (compras)
        public ICollection<ClienteArticulo> Compradores { get; set; }
    }
}
