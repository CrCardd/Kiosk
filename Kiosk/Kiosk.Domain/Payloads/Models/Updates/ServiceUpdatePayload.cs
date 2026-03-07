namespace Kiosk.Domain.Payloads.Models.Updates;

public record ServiceUpdatePayload
(
    string? Name = null,
    string? Image = null,
    bool? Available = null
);