
namespace Kiosk.Application.Features.Variant_.Create;

public record CreateResponse(
    Guid Id,
    string Name,
    string Image,
    bool Available,
    int Ingredients,
    bool Surpass,
    Guid ServiceId
);
