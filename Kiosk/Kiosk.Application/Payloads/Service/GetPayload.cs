using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Service;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}
    public required string Image {get;init;}
    public required bool Available {get;init;}
    public required ICollection<GetVariant> Variants {get;init;}

    public static GetPayload ToDto(ServiceModel service)
    {
        return new GetPayload
        {
            Id = service.Id,
            Available = service.Available,
            Image = service.Image,
            Name = service.Name,
            Variants = service.Variants.Select(GetVariant.ToDto).ToList()
        };
    }
}

public record GetVariant
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}
    public required decimal Price {get;init;}
    public required string Image {get;init;}
    public required int Ingredients {get;init;}
    public required bool Surpass {get;init;}
    public required bool Available {get;init;}
    public required ICollection<GetVariant> Parts {get;init;}
    public required ICollection<GetVariantIngredient> VariantIngredients {get;init;}

    public static GetVariant ToDto(VariantModel variant)
    {
        return new GetVariant
        {
            Id = variant.Id,
            Available = variant.Available,
            Image = variant.Image,
            Name = variant.Name,
            Surpass = variant.Surpass,
            Ingredients = variant.Ingredients,
            VariantIngredients = variant.VariantIngredients.Select(GetVariantIngredient.ToDto).ToList(),
            Parts = variant.Parts.Select(p => ToDto(p.Part)).ToList(),
            Price = variant.PriceHistoryVariants
                .Where(phv => phv.DisabledAt == null)
                .OrderByDescending(phv => phv.CreatedAt)
                .First()
                .Price
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
                .Price,
        };
    }
}