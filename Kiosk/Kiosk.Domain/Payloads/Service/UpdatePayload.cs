namespace Kiosk.Domain.Payloads.Service;

public record UpdatePayload
(
    string? Name = null,
    string? Image = null,
    bool? Available = null
);