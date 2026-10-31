namespace Kiosk.Application.Features.Organization_.Open;

public record OpenRequest
{
    public required Guid UserId {get;set;}
    public required string Email {get;set;}
    public required Guid OrganizationId {get;set;}
    public required DateTimeOffset ExpiresAt {get;set;}
}