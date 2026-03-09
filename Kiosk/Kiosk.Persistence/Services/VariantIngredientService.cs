using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class VariantIngredientService(
    KioskContext ctx
) : IVariantIngredientService
{
    public async Task<Result<VariantIngredientGetPayload>> Create(VariantIngredientCreatePayload payload, CancellationToken cancellationToken)
    {
        var variant = ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Where(v => v.Id == payload.VariantId)
            .FirstOrDefault();
        if(variant is null)
            return "Referenced Variant not found";
     
        var ingredient = ctx.Ingredients
            .Where(v => v.DisabledAt == null)
            .Where(v => v.Id == payload.IngredientId)
            .FirstOrDefault();
        if(ingredient is null)
            return "Referenced Ingredient not found";

        var variantIngredient = new VariantIngredient
        {
            Available=payload.Available,
            Variant=variant,
            VariantId=variant.Id,
            Ingredient=ingredient,
            IngredientId=ingredient.Id
        };
        ctx.VariantIngredients.Add(variantIngredient);
        return new VariantIngredientGetPayload(
            variantIngredient.Id,
            variantIngredient.Available,
            variantIngredient.VariantId,
            variantIngredient.IngredientId
        );
    }
}