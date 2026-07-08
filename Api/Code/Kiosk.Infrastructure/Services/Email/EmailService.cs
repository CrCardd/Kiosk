using Kiosk.Application.Services.Email;
using Kiosk.Domain.Models;
using Resend;

namespace Kiosk.Infrastructure.Services.Email;

public class EmailService(
    IResend resendService
) : IEmailService
{
    public async Task Send(string to, string from, string subject, string body)
    {
        var message = new EmailMessage();
        message.From = from;
        message.To.Add(to);
        message.Subject = subject;
        message.HtmlBody = body;

        Console.WriteLine("\n\n\n==================================");
        Console.WriteLine(from);
        Console.WriteLine(to);
        Console.WriteLine(subject);
        Console.WriteLine("==================================\n\n\n");

        var result = await resendService.EmailSendAsync( message );
    }
}