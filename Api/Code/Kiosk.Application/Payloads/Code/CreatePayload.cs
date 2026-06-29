namespace Kiosk.Application.Payloads.Code;

public record CreatePayload
{
    public required string Code {get;init;}
    public required Guid OrganizationId {get;init;}
    public required DateTime StartDate {get;init;}
    public required DateTime EndDate {get;init;}
}