using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.AuthCode;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Email {get;init;}
    public required string Code {get;init;}
    public required DateTime StartDate {get;init;}
    public required DateTime EndDate {get;init;}

    public static GetPayload FromGetPayload(AuthCodeModel authcode)
    {
        return new GetPayload
        {
            Id = authcode.Id,
            Code = authcode.Code,
            Email = authcode.Email,
            StartDate = authcode.StartDate,
            EndDate = authcode.EndDate,
        };
    }
}