namespace DotNetExam.Data.Models
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        // Relación con Artículos
        public ICollection<TiendaArticulo> ArticulosEnTienda { get; set; }
    }
}
