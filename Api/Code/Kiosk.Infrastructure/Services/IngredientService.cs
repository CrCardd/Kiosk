
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.Ingredient;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Infrastructure.Services;

public class IngredientService(
    KioskContext ctx
) : IIngredientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            .FirstOrDefault();

        if(service == null)
            return new NotFoundEx("Referenced Service not found");

        var ingredient = new IngredientModel
        {
            Name = payload.Name,
            Available = payload.Available ?? true,
            ServiceId = payload.ServiceId,
            Service = service,
            Quantity = payload.Quantity
        };
        var price = new PriceHistoryIngredientModel
        {
            Price=payload.Price,
            Ingredient=ingredient,
            IngredientId=ingredient.Id
        };

        ctx.Ingredients.Add(ingredient);
        ctx.PriceHistoryIngredients.Add(price);

        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(ingredient);
    }
}