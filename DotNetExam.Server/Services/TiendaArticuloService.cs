using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services;

public class TiendaArticuloService : ITiendaArticuloService
{
    private readonly ApplicationDbContext _context;

    public TiendaArticuloService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AsociarArticuloATienda(int tiendaId, int articuloId, DateTime fecha)
    {
        var asociacion = new TiendaArticulo
        {
            TiendaId = tiendaId,
            ArticuloId = articuloId,
            Fecha = fecha
        };
        _context.TiendaArticulos.Add(asociacion);
        _context.SaveChanges();
    }

    public void DesasociarArticuloDeTienda(int tiendaId, int articuloId)
    {
        var asociacion = _context.TiendaArticulos
            .FirstOrDefault(ta => ta.TiendaId == tiendaId && ta.ArticuloId == articuloId);
        if (asociacion != null)
        {
            _context.TiendaArticulos.Remove(asociacion);
            _context.SaveChanges();
        }
    }

    public IEnumerable<TiendaArticulo> ObtenerArticulosPorTienda(int tiendaId)
    {
        return _context.TiendaArticulos
            .Where(ta => ta.TiendaId == tiendaId)
            .ToList();
    }
}