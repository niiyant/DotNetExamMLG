using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services;

public class ClienteService : IClienteService
{
    private readonly ApplicationDbContext _context;

    public ClienteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cliente> ObtenerTodosLosClientes()
    {
        return _context.Clientes.ToList();
    }

    public Cliente ObtenerClientePorId(int id)
    {
        return _context.Clientes.Find(id);
    }

    public void AgregarCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void ActualizarCliente(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void EliminarCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}