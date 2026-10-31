using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Organization;

public record GetPayload : IBaseGetPayload<OrganizationModel, GetPayload>
{
    public Guid Id {get;init;}
    public required string Name {get;init;}

    public static GetPayload ToDto(OrganizationModel organization)
    {
        return new GetPayload
        {
            Id = organization.Id,
            Name = organization.Name,
        };
    }
}