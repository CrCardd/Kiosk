
namespace Kiosk.Application.Features.VariantIngredient_.Create;

public record CreateResponse(
    Guid Id,
    bool Available,
    Guid VariantId,
    Guid IngredientId
);
