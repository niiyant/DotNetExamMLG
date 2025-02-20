using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services;

public class ArticuloService : IArticuloService
{
    private readonly ApplicationDbContext _context;

    public ArticuloService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Articulo> ObtenerTodosLosArticulos()
    {
        return _context.Articulos.ToList();
    }

    public Articulo ObtenerArticuloPorId(int id)
    {
        return _context.Articulos.Find(id);
    }

    public void AgregarArticulo(Articulo articulo)
    {
        _context.Articulos.Add(articulo);
        _context.SaveChanges();
    }

    public void ActualizarArticulo(Articulo articulo)
    {
        _context.Articulos.Update(articulo);
        _context.SaveChanges();
    }

    public void EliminarArticulo(int id)
    {
        var articulo = _context.Articulos.Find(id);
        if (articulo != null)
        {
            _context.Articulos.Remove(articulo);
            _context.SaveChanges();
        }
    }
}