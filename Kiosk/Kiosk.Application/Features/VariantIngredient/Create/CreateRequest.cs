using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.VariantIngredient_.Create;

public record CreateRequest(
    bool? Available,
    [Required] Guid VariantId,
    [Required] Guid IngredientId
);
