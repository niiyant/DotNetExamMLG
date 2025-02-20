using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using DotNetExam.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetExam.Business.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly string _key;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
        _key = "secret"; // Misma clave usada en Program.cs
    }

    public string Login(string email, string password)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
        if (usuario == null || !VerifyPasswordHash(password, usuario.PasswordHash))
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

    public void Register(Usuario usuario, string password)
    {
        byte[] passwordHash;
        CreatePasswordHash(password, out passwordHash);
        usuario.PasswordHash = passwordHash;

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}