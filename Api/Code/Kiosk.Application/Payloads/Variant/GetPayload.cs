using Kiosk.Application.Payloads.Service;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Variant;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}
    public required decimal Price {get;init;}
    public required string Image {get;init;}
    public required int Ingredients {get;init;}
    public required bool Surpass {get;init;}
    public required bool Available {get;init;}
    public required GetService Service {get;init;}
    public required ICollection<GetPayload> Parts {get;init;}
    public required ICollection<GetVariantIngredient> VariantIngredients {get;init;}

    public static GetPayload ToDto(VariantModel variant)
    {
        return new GetPayload
        {
            Id = variant.Id,
            Available = variant.Available,
            Image = variant.Image,
            Name = variant.Name,
            Ingredients = variant.Ingredients,
            Surpass = variant.Surpass,
            Parts = variant.Parts.Select(p => ToDto(p.Part)).ToList(),
            Price = variant.PriceHistoryVariants
                .Where(phv => phv.DisabledAt == null)
                .OrderByDescending(phv => phv.CreatedAt)
                .First()
                .Price,
            Service = GetService.ToDto(variant.Service),
            VariantIngredients = variant.VariantIngredients.Select(GetVariantIngredient.ToDto).ToList()
        };
    }
}

public record GetVariantIngredient
{
    public required Guid Id {get;init;}
    public required bool Available {get;init;}
    public required GetIngredient Ingredient {get;init;}

    public static GetVariantIngredient ToDto(VariantIngredientModel variantIngredient)
    {
        return new GetVariantIngredient
        {
            Id = variantIngredient.Id,
            Available = variantIngredient.Available,
            Ingredient = GetIngredient.ToDto(variantIngredient.Ingredient)
        };
    }
}

public record GetIngredient
{
    public required Guid Id {get;init;}
    public required bool Available {get;init;}
    public required string Name {get;init;}
    public required decimal Price {get;init;}

    public static GetIngredient ToDto(IngredientModel ingredient)
    {
        return new GetIngredient
        {
            Id = ingredient.Id,
            Available = ingredient.Available,
            Name = ingredient.Name,
            Price = ingredient.PriceHistoryIngredients
                .Where(phi => phi.DisabledAt == null)
                .OrderByDescending(phi => phi.CreatedAt)
                .First()
                .Price
        };
    }
}
public record GetService
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}
    public required string Image {get;init;}

    public static GetService ToDto(ServiceModel service)
    {
        return new GetService
        {
            Id = service.Id,
            Image = service.Image,
            Name = service.Name
        };
    }
}