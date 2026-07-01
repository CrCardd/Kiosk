using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.VariantIngredient;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Infrastructure.Services;

public class VariantIngredientService(
    KioskContext ctx
) : IVariantIngredientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var variant = ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Where(v => v.Id == payload.VariantId)
            .FirstOrDefault();
        if(variant is null)
            return new NotFoundEx("Referenced Variant not found");
     
        var ingredient = ctx.Ingredients
            .Where(v => v.DisabledAt == null)
            .Where(v => v.Id == payload.IngredientId)
            .FirstOrDefault();
        if(ingredient is null)
            return new NotFoundEx("Referenced Ingredient not found");

        var variantIngredient = new VariantIngredientModel
        {
            Available=payload.Available ?? true,
            Variant=variant,
            VariantId=variant.Id,
            Ingredient=ingredient,
            IngredientId=ingredient.Id
        };
        ctx.VariantIngredients.Add(variantIngredient);
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(variantIngredient);
    }
}