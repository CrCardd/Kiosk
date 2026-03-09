
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class IngredientService(
    KioskContext ctx
) : IIngredientService
{
    public async Task<Result<IngredientGetPayload>> Create(IngredientCreatePayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            .FirstOrDefault();

        if(service == null)
            return "Referenced Service not found";

        var ingredient = new Ingredient
        {
            Name=payload.Name,
            Available=payload.Available,
            ServiceId=payload.ServiceId,
            Service=service,
            Quantity=payload.Quantity
        };
        var price = new PriceHistoryIngredient
        {
            Price=payload.Price,
            Ingredient=ingredient,
            IngredientId=ingredient.Id
        };

        ctx.Ingredients.Add(ingredient);
        ctx.PriceHistoryIngredients.Add(price);

        await ctx.SaveChangesAsync(cancellationToken);
        var value = new IngredientGetPayload(
            ingredient.Id,
            ingredient.Name,
            price.Price,
            ingredient.Available,
            ingredient.ServiceId,
            ingredient.Quantity
        );
        return value;
    }
}