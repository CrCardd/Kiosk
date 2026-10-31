using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Provider;

public record GetPayload : IBaseGetPayload<OAuthProviderModel, GetPayload>
{
    public required Guid Id {get;init;}
    public required string Subject {get;init;}
    public required string Email {get;init;}
    public required string Name {get;init;}
    public required string Picture {get;init;}
    public required OAuthProviderType Type {get;init;}
 

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
        };
    }
}