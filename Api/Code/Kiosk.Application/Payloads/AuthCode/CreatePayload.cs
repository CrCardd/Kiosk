using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.AuthCode;

public record CreatePayload
{
    public required string Email {get;init;}
    public required string Code {get;init;}
    public required DateTime StartDate {get;init;}
    public required DateTime EndDate {get;init;}
}