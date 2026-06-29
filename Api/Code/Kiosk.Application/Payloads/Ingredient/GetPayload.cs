using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Ingredient;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}
    public required decimal Price {get;init;}
    public required bool Available {get;init;}
    public required Guid ServiceId {get;init;}
    public int? Quantity {get;init;}

    public static GetPayload ToDto(IngredientModel ingredient)
    {
        return new GetPayload
        {
            Id = ingredient.Id,
            Available = ingredient.Available,
            Name = ingredient.Name,
            Price = ingredient.PriceHistoryIngredients
                .Where(phi => phi.DisabledAt == null)
                .OrderByDescending(phi => phi.CreatedAt)
                .First()
                .Price,
            ServiceId = ingredient.ServiceId
        };
    }
}