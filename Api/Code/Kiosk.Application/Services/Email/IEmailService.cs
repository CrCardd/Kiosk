using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Email;

public interface IEmailService : IBaseService
{
    Task Send(string to, string from, string subject, string body);
}