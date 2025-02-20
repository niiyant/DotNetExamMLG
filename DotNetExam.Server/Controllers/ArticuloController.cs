using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam.Business.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticuloController : ControllerBase
{
    private readonly IArticuloService _articuloService;

    public ArticuloController(IArticuloService articuloService)
    {
        _articuloService = articuloService;
    }

    [HttpGet]
    public IActionResult ObtenerTodosLosArticulos()
    {
        var articulos = _articuloService.ObtenerTodosLosArticulos();
        return Ok(articulos);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerArticuloPorId(int id)
    {
        var articulo = _articuloService.ObtenerArticuloPorId(id);
        if (articulo == null) return NotFound();
        return Ok(articulo);
    }

    [HttpPost]
    public IActionResult AgregarArticulo([FromBody] Articulo articulo)
    {
        _articuloService.AgregarArticulo(articulo);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarArticulo(int id, [FromBody] Articulo articulo)
    {
        articulo.Id = id;
        _articuloService.ActualizarArticulo(articulo);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarArticulo(int id)
    {
        _articuloService.EliminarArticulo(id);
        return Ok();
    }
}