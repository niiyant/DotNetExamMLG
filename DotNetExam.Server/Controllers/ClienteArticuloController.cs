using DotNetExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam.Business.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteArticuloController : ControllerBase
{
    private readonly IClienteArticuloService _clienteArticuloService;

    public ClienteArticuloController(IClienteArticuloService clienteArticuloService)
    {
        _clienteArticuloService = clienteArticuloService;
    }

    [HttpPost("comprar")]
    public IActionResult RegistrarCompra([FromBody] ClienteArticuloRequest request)
    {
        _clienteArticuloService.RegistrarCompra(request.ClienteId, request.ArticuloId, request.Fecha);
        return Ok();
    }

    [HttpDelete("eliminar-compra/{clienteId}/{articuloId}")]
    public IActionResult EliminarCompra(int clienteId, int articuloId)
    {
        _clienteArticuloService.EliminarCompra(clienteId, articuloId);
        return Ok();
    }

    [HttpGet("cliente/{clienteId}")]
    public IActionResult ObtenerComprasPorCliente(int clienteId)
    {
        var compras = _clienteArticuloService.ObtenerComprasPorCliente(clienteId);
        return Ok(compras);
    }
}

public class ClienteArticuloRequest
{
    public int ClienteId { get; set; }
    public int ArticuloId { get; set; }
    public DateTime Fecha { get; set; }
}