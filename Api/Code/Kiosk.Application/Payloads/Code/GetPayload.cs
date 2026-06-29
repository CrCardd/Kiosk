using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Code;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Code {get;init;}
    public required Guid OrganizationId {get;init;}
    public required DateTime StartDate {get;init;}
    public required DateTime EndDate {get;init;}

    public static GetPayload ToDto(CodeModel code)
    {
        return new GetPayload
        {
            Id = code.Id,
            Code = code.Code,
            EndDate = code.EndDate,
            StartDate = code.StartDate,
            OrganizationId = code.OrganizationId
        };
    }
}