namespace Kiosk.Application.Payloads.Segment;

public record CreatePayload
{
    public required Guid CreatedBy {get;set;}
    public required string Name {get;set;}

    /// <summary>
    /// OrganizationId, possibly null if its an independent Segment
    /// </summary>
    public Guid? BelongsTo {get;set;} = null;
}