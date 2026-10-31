namespace Kiosk.Application.Features.Segment_.Open;

public record OpenRequest
{
    public required Guid UserId {get;set;}
    public required string Email {get;set;}
    public required Guid? SegmentId {get;set;}
    public required DateTimeOffset ExpiresAt {get;set;}
}