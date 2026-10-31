namespace Kiosk.Application.Payloads.Organization;

public record CreatePayload
{
    public required Guid CreatedBy {get;init;}
    public required string Name {get;init;}
}