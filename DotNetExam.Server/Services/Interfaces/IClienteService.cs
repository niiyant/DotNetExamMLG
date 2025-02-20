using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services.Interfaces;

public interface IClienteService
{
    IEnumerable<Cliente> ObtenerTodosLosClientes();
    Cliente ObtenerClientePorId(int id);
    void AgregarCliente(Cliente cliente);
    void ActualizarCliente(Cliente cliente);
    void EliminarCliente(int id);
}