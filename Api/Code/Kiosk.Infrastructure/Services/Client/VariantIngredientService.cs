using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.VariantIngredient;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class VariantIngredientService(
    KioskContext ctx
) : IVariantIngredientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var variant = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.Service)
            .Where(v => v.Id == payload.VariantId)
            .FirstOrDefaultAsync(cancellationToken);
        if(variant is null)
            throw new NotFoundEx("Referenced Variant not found");
     
        var ingredient = await ctx.Ingredients
            .Where(v => v.DisabledAt == null)
            .Include(v => v.Service)
            .Where(v => v.Id == payload.IngredientId)
            .FirstOrDefaultAsync(cancellationToken);
        if(ingredient is null)
            throw new NotFoundEx("Referenced Ingredient not found");

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
        return Result.Created(GetPayload.ToDto(variantIngredient));
    }
}