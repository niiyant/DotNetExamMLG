using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services.Interfaces;

public interface ITiendaService
{
    IEnumerable<Tienda> ObtenerTodasLasTiendas();
    Tienda ObtenerTiendaPorId(int id);
    void AgregarTienda(Tienda tienda);
    void ActualizarTienda(Tienda tienda);
    void EliminarTienda(int id);
}