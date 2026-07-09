using Kiosk.Application.Payloads._Misc;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Email;

public interface IEmailService : IBaseService
{
    Task Send(EmailPayload payload, CancellationToken cancellationToken);
    Task SendVerificationEmail(VerificationCodePayload payload, CancellationToken cancellationToken);
    Task SendPasswordEmail(PasswordPayload payload, CancellationToken cancellationToken);
}