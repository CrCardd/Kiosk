
namespace Kiosk.Application.Features.Service_.Create;

public record CreateResponse(
    Guid Id,
    string Name,
    string Image,
    bool Available
);
