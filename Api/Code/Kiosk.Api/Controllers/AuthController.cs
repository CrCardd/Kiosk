using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.Create;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;
using Kiosk.Application.Features.Auth_.Provider;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Auth)]
public class AuthController(
    Login login,
    ProviderLogin provider
) : ApiController
{
    [HttpPost]
    public async Task<ActionResult<Result<GetTokenPayload>>> Login(
        LoginRequest request, CancellationToken cancellationToken
    )
    {
        var response = await login.ExecuteAsync(request, cancellationToken);
        return response;
    }

    [HttpPost("provider")]
    public async Task<ActionResult<Result<GetTokenPayload>>> ProviderLogin(
        [FromQuery] string idToken, 
        [FromQuery] string providerType, 
        CancellationToken cancellationToken
    )
    {
        var payload = new ProviderRequest
        {
            IdToken = idToken,
            Provider = providerType
        };

        var response = await provider.ExecuteAsync(payload, cancellationToken);
        return response;
    }
}
