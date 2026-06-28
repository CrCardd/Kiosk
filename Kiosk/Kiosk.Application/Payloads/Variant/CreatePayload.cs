namespace Kiosk.Application.Payloads.Variant;

public record CreatePayload
{
    public required string Name {get;init;}
    public required decimal Price {get;init;}
    public required string Image {get;init;}
    public int? Ingredients {get;init;}
    public bool? Surpass {get;init;}
    public bool? Available {get;init;}
    public required Guid ServiceId {get;init;}
    public ICollection<Guid> Parts {get;init;} = [];
}