using Kiosk.Application.Features.Auth_;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Auth;

public interface IJwtService : IBaseService
{
    public GetTokenPayload Generate(CreateTokenPayload payload, int durationMinutes = 120);
}