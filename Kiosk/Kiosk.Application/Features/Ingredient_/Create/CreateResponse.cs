
namespace Kiosk.Application.Features.Ingredient_.Create;

public record CreateResponse(
    Guid Id,
    string Name,
    decimal Price,
    int? Quantity,
    Guid ServiceId
);
