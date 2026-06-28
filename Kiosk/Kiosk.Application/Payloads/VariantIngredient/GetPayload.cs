using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.VariantIngredient;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required bool Available {get;init;}
    public required GetVariant Variant {get;init;}
    public required GetIngredient Ingredient {get;init;}

    public static GetPayload ToDto(VariantIngredientModel variantIngredient)
    {
        return new GetPayload
        {
            Id = variantIngredient.Id,
            Available = variantIngredient.Available,
            Ingredient = GetIngredient.ToDto(variantIngredient.Ingredient),
            Variant = GetVariant.ToDto(variantIngredient.Variant)
        };
    }
}

public record GetVariant
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}

    public static GetVariant ToDto(VariantModel variant)
    {
        return new GetVariant
        {
            Id = variant.Id,
            Name = variant.Name
        };
    }
}

public record GetIngredient
{
    public required Guid Id {get;init;}
    public required string Name {get;init;}

    public static GetIngredient ToDto(IngredientModel ingredient)
    {
        return new GetIngredient
        {
            Id = ingredient.Id,
            Name = ingredient.Name
        };
    }
}