namespace Kiosk.Domain.Payloads.Update;

public record ServiceUpdatePayload
(
    string? Name = null,
    string? Image = null,
    bool? Available = null
);