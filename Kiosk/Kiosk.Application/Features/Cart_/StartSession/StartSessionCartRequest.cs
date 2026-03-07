using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.Cart_.StartSession;

public record StartSessionCartRequest(
    [property: Required]
    [property: MaxLength(31)]
    [property: MinLength(3)]
    string Client,
    
    [property: Required]
    [property: MaxLength(31)]
    [property: MinLength(3)]
    string SessionToken
);
