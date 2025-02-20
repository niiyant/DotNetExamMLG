using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services.Interfaces;

public interface IArticuloService
{
    IEnumerable<Articulo> ObtenerTodosLosArticulos();
    Articulo ObtenerArticuloPorId(int id);
    void AgregarArticulo(Articulo articulo);
    void ActualizarArticulo(Articulo articulo);
    void EliminarArticulo(int id);
}