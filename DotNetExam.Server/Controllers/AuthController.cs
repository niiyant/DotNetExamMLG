using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam.Business.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        try
        {
            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Email = request.Email
            };

            _authService.Register(usuario, request.Password, request.Apellidos, request.Direccion);
            return Ok(new { message = "Usuario registrado exitosamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var token = _authService.Login(request.Email, request.Password);
        if (token == null)
            return Unauthorized(new { message = "Credenciales inválidas" });

        return Ok(new { token });
    }
}

public class RegisterRequest
{
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}