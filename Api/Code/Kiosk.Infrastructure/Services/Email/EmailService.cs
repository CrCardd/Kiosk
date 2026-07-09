using System.Reflection;
using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Services.Email;
using Kiosk.Domain.Models;
using Resend;

namespace Kiosk.Infrastructure.Services.Email;

public class EmailService(
    IResend resendService
) : IEmailService
{
    public async Task Send(EmailPayload payload, CancellationToken cancellationToken)
    {
        var message = new EmailMessage
        {
            From = payload.From,
            Subject = payload.Subject,
            HtmlBody = payload.Body
        };
        message.To.Add(payload.To);
        var result = await resendService.EmailSendAsync(message);
    }

    public async Task SendVerificationEmail(VerificationCodePayload payload, CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var stream = assembly.GetManifestResourceStream(
            "Kiosk.Infrastructure.Services.Email.Templates.VerificationCode.html");
        using var reader = new StreamReader(stream!);
        var html = await reader.ReadToEndAsync();
        html = TemplateRenderer.Render(html, new()
        {
            ["Code"] = payload.Code,
            ["Minutes"] = payload.Minutes.ToString(),
            ["Year"] = DateTime.UtcNow.Year.ToString(),
        });

        var message = new EmailMessage
        {
            Subject = payload.Subject,
            From = payload.From,
            HtmlBody = html
        };
        message.To.Add(payload.To);
        var result = await resendService.EmailSendAsync(message);
    }

    public async Task SendPasswordEmail(PasswordPayload payload, CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var stream = assembly.GetManifestResourceStream(
            "Kiosk.Infrastructure.Services.Email.Templates.Password.html");
        using var reader = new StreamReader(stream!);
        var html = await reader.ReadToEndAsync();
        html = TemplateRenderer.Render(html, new()
        {
            ["Link"] = $"{Environment.GetEnvironmentVariable("UI_URL")}/{payload.Token.Token}",
            ["Year"] = DateTime.UtcNow.Year.ToString(),
            ["Minutes"] = payload.Minutes.ToString(),
        });

        var message = new EmailMessage
        {
            Subject = payload.Subject,
            From = payload.From,
            HtmlBody = html
        };
        message.To.Add(payload.To);
        var result = await resendService.EmailSendAsync(message);
    }
}