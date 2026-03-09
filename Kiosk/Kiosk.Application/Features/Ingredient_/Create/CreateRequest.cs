using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.Ingredient_.Create;

public record CreateRequest(
    string Name,
    decimal Price,
    Guid ServiceId,
    bool? Available = null,
    int? Quantity = null
);
