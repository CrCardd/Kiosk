using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Code;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Code {get;init;}
    public required GetOrganization Organization {get;init;}
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
            Organization = GetOrganization.ToDto(code.Organization)
        };
    }
}

public record GetOrganization
{
    public required Guid Id {get;init;}
    public required string Email {get;init;}

    public static GetOrganization ToDto(OrganizationModel organization)
    {
        return new GetOrganization
        {
            Id = organization.Id,
            Email = organization.Email,
        };
    }
}

