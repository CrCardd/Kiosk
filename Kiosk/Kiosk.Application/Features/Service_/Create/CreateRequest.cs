
using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.Service_.Create;

public record CreateRequest(
    [Required][MaxLength(31)][MinLength(3)] string Name,
    [Required][MaxLength(31)][MinLength(3)] string Image,
    bool Available = true
);
