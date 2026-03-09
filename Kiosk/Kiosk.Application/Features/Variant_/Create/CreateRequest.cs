using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.Variant_.Create;

public record CreateRequest(
    [Required][MinLength(3)][MaxLength(31)] string Name,
    [Required][MinLength(3)][MaxLength(31)] string Image,
    decimal Price,
    int? Ingredients,
    bool? Surpass,
    bool? Available,
    [Required] Guid ServiceId
);
