using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Data.Models;
using DotNetExam.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetExam.Business.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly string _key;

    public AuthService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _key = configuration.GetValue<string>("Jwt:Key") ?? throw new ArgumentNullException(nameof(configuration), "Jwt:Key is not configured.");
    }

    public string Login(string email, string password)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
        if (usuario == null || !VerifyPasswordHash(password, usuario.PasswordHash, usuario.PasswordSalt))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public void Register(Usuario usuario, string password, string apellidos, string direccion)
    {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);
        usuario.PasswordHash = passwordHash;
        usuario.PasswordSalt = passwordSalt; // Guarda el salt

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        var cliente = new Cliente
        {
            Id = usuario.Id != 0 ? usuario.Id : GetNextClienteId(),
            Nombre = usuario.Nombre,
            Apellidos = apellidos,
            Direccion = direccion
        };
        _context.Clientes.Add(cliente);
        _context.SaveChanges();

    }
    private int GetNextClienteId()
    {
        return (_context.Clientes.Max(c => (int?)c.Id) ?? 0) + 1;
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
