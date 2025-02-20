using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services;

public class TiendaService : ITiendaService
{
    private readonly ApplicationDbContext _context;

    public TiendaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Tienda> ObtenerTodasLasTiendas()
    {
        return _context.Tiendas.ToList();
    }

    public Tienda ObtenerTiendaPorId(int id)
    {
        return _context.Tiendas.Find(id);
    }

    public void AgregarTienda(Tienda tienda)
    {
        _context.Tiendas.Add(tienda);
        _context.SaveChanges();
    }

    public void ActualizarTienda(Tienda tienda)
    {
        _context.Tiendas.Update(tienda);
        _context.SaveChanges();
    }

    public void EliminarTienda(int id)
    {
        var tienda = _context.Tiendas.Find(id);
        if (tienda != null)
        {
            _context.Tiendas.Remove(tienda);
            _context.SaveChanges();
        }
    }
}