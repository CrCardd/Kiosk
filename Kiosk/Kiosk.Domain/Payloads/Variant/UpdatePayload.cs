namespace Kiosk.Domain.Payloads.Variant;

public record UpdatePayload(
    string? Name = null,
    decimal? Price = null,
    string? Image = null,
    int? Ingredients = null,
    bool? Surpass = null,
    bool? Available = null,
    ICollection<Guid>? Parts = null
);
