
namespace Kiosk.Application.Features.Service_.Update;

public record UpdateResponse(
    Guid Id,
    string Name,
    string Image,
    bool Available
);
