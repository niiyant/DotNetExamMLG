using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services.Interfaces;

public interface IClienteArticuloService
{
    void RegistrarCompra(int clienteId, int articuloId, DateTime fecha);
    void EliminarCompra(int clienteId, int articuloId);
    IEnumerable<ClienteArticulo> ObtenerComprasPorCliente(int clienteId);
}