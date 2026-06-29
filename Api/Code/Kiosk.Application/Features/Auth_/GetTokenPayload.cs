using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Features.Auth_;

public record GetTokenPayload
{
    public required string Token {get;init;}
}