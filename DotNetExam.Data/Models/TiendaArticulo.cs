namespace DotNetExam.Data.Models
{
    public class TiendaArticulo
    {
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }

        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
