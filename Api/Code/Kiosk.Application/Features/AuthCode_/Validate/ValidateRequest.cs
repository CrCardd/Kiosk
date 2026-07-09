namespace Kiosk.Application.Features.AuthCode_.Validate;

public record ValidateRequest
{
    public required string Email {get;init;}
    public required string Code {get;init;}
}