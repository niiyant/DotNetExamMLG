using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam.Business.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TiendaController : ControllerBase
{
    private readonly ITiendaService _tiendaService;

    public TiendaController(ITiendaService tiendaService)
    {
        _tiendaService = tiendaService;
    }

    [HttpGet]
    public IActionResult ObtenerTodasLasTiendas()
    {
        var tiendas = _tiendaService.ObtenerTodasLasTiendas();
        return Ok(tiendas);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerTiendaPorId(int id)
    {
        var tienda = _tiendaService.ObtenerTiendaPorId(id);
        if (tienda == null) return NotFound();
        return Ok(tienda);
    }

    [HttpPost]
    public IActionResult AgregarTienda([FromBody] Tienda tienda)
    {
        _tiendaService.AgregarTienda(tienda);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarTienda(int id, [FromBody] Tienda tienda)
    {
        tienda.Id = id;
        _tiendaService.ActualizarTienda(tienda);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarTienda(int id)
    {
        _tiendaService.EliminarTienda(id);
        return Ok();
    }
}