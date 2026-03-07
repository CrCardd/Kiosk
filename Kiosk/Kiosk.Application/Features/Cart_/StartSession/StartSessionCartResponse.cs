
namespace Kiosk.Application.Features.Cart_.StartSession;

public record StartSessionCartResponse(
    Guid Id,
    string SessionToken,
    string Client
);
