using DotNetExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam.Business.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiendaArticuloController : ControllerBase
{
    private readonly ITiendaArticuloService _tiendaArticuloService;

    public TiendaArticuloController(ITiendaArticuloService tiendaArticuloService)
    {
        _tiendaArticuloService = tiendaArticuloService;
    }

    [HttpPost("asociar")]
    public IActionResult AsociarArticuloATienda([FromBody] TiendaArticuloRequest request)
    {
        _tiendaArticuloService.AsociarArticuloATienda(request.TiendaId, request.ArticuloId, request.Fecha);
        return Ok();
    }

    [HttpDelete("desasociar/{tiendaId}/{articuloId}")]
    public IActionResult DesasociarArticuloDeTienda(int tiendaId, int articuloId)
    {
        _tiendaArticuloService.DesasociarArticuloDeTienda(tiendaId, articuloId);
        return Ok();
    }

    [HttpGet("tienda/{tiendaId}")]
    public IActionResult ObtenerArticulosPorTienda(int tiendaId)
    {
        var articulos = _tiendaArticuloService.ObtenerArticulosPorTienda(tiendaId);
        return Ok(articulos);
    }
    public class TiendaArticuloRequest
    {
        public int TiendaId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
