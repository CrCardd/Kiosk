
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.Ingredient;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;
using Kiosk.Infrastructure.Context;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class IngredientService(
    KioskContext ctx
) : IIngredientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            .Include(s => s.Segment)
            .FirstOrDefaultAsync(cancellationToken);

        if(service == null)
            throw new NotFoundEx("Referenced Service not found");

        var ingredient = new IngredientModel
        {
            Name = payload.Name,
            Available = payload.Available ?? true,
            ServiceId = payload.ServiceId,
            Service = service,
            Quantity = payload.Quantity,
            Segment = service.Segment,
            SegmentId = service.SegmentId
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
        return Result.Created(GetPayload.ToDto(ingredient));
    }
}