using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam.Business.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public IActionResult ObtenerTodosLosClientes()
    {
        var clientes = _clienteService.ObtenerTodosLosClientes();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerClientePorId(int id)
    {
        var cliente = _clienteService.ObtenerClientePorId(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult AgregarCliente([FromBody] Cliente cliente)
    {
        _clienteService.AgregarCliente(cliente);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarCliente(int id, [FromBody] Cliente cliente)
    {
        cliente.Id = id;
        _clienteService.ActualizarCliente(cliente);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarCliente(int id)
    {
        _clienteService.EliminarCliente(id);
        return Ok();
    }
}