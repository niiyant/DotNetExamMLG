using DotNetExam.Entities.Models;

namespace DotNetExam.Business.Services.Interfaces;

public interface IAuthService
{
    string Login(string email, string password);
    void Register(Usuario usuario, string password);
}