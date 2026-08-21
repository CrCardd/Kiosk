using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.User;

public record GetPayload
{
    public Guid Id {get;init;}
    public required string Name {get;init;}
    public required string Email {get;init;}
    public required string Password {get;init;}

    public static GetPayload ToDto(UserModel organization)
    {
        return new GetPayload
        {
            Id = organization.Id,
            Name = organization.Name,
            Email = organization.Email,
            Password = organization.Password
        };
    }
}