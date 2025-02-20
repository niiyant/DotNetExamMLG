using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services.Interfaces;

public interface ITiendaArticuloService
{
    void AsociarArticuloATienda(int tiendaId, int articuloId, DateTime fecha);
    void DesasociarArticuloDeTienda(int tiendaId, int articuloId);
    IEnumerable<TiendaArticulo> ObtenerArticulosPorTienda(int tiendaId);
}