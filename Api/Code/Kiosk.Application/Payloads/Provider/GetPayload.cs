using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Provider;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Subject {get;init;}
    public required string Email {get;init;}
    public required string Name {get;init;}
    public required string Picture {get;init;}
    public required OAuthProviderType Type {get;init;}
 
    public required GetOrganization Organization {get;init;}

    public static GetPayload ToDto(OAuthProviderModel provider)
    {
        return new GetPayload
        {
            Id = provider.Id,
            Name = provider.Name,
            Email = provider.Email,
            Picture = provider.Picture,
            Subject = provider.Subject,
            Type = provider.Type,
            Organization = GetOrganization.ToDto(provider.Organization)
        };
    }
}

public record GetOrganization
{
    public Guid Id {get;init;}
    public required string Name {get;init;}
    public required string Password {get;init;}

    public static GetOrganization ToDto(OrganizationModel organization)
    {
        return new GetOrganization
        {
            Id = organization.Id,
            Name = organization.Name,
            Password = organization.Password
        };
    }
}