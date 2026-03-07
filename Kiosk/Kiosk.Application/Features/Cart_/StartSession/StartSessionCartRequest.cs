using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.Cart_.StartSession;

public record StartSessionCartRequest(
    [Required][MaxLength(31)][MinLength(3)] string Client,
    [Required][MaxLength(31)][MinLength(3)] string SessionToken
);
