namespace Kiosk.Application.Services.Auth;

public interface IPasswordService : IBaseService
{
    public string Hash(string password);
    public bool Compare(string password, string hashedPassword);
    
}