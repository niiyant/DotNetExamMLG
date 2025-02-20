using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Data.Models;

namespace DotNetExam.Business.Services;

public class ClienteArticuloService : IClienteArticuloService
{
    private readonly ApplicationDbContext _context;

    public ClienteArticuloService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void RegistrarCompra(int clienteId, int articuloId, DateTime fecha)
    {
        var compra = new ClienteArticulo
        {
            ClienteId = clienteId,
            ArticuloId = articuloId,
            Fecha = fecha
        };
        _context.ClienteArticulos.Add(compra);
        _context.SaveChanges();
    }

    public void EliminarCompra(int clienteId, int articuloId)
    {
        var compra = _context.ClienteArticulos
            .FirstOrDefault(ca => ca.ClienteId == clienteId && ca.ArticuloId == articuloId);
        if (compra != null)
        {
            _context.ClienteArticulos.Remove(compra);
            _context.SaveChanges();
        }
    }

    public IEnumerable<ClienteArticulo> ObtenerComprasPorCliente(int clienteId)
    {
        return _context.ClienteArticulos
            .Where(ca => ca.ClienteId == clienteId)
            .ToList();
    }
}