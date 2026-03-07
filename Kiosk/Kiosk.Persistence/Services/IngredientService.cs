using System.Dynamic;
using AutoMapper.Configuration.Annotations;
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Models;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class IngredientService(
    KioskContext ctx
) : IIngredientService
{
    public async Task<IngredientPayload?> Create(IngredientPayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            .FirstOrDefault();

        if(service == null)
            return null;

        var ingredient = new Ingredient
        {
            Name=payload.Name,
            Available=payload.Available,
            ServiceId=payload.ServiceId,
            Service=service,
            Quantity=payload.Quantity
        };

        ctx.Ingredients.Add(ingredient);
        await ctx.SaveChangesAsync(cancellationToken);
        return new(
            payload.Name,
            payload.Available,
            payload.ServiceId,
            payload.Quantity,
            payload.Id
        );
    }
}