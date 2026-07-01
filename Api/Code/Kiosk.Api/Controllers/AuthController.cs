using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.Create;
using Kiosk.Application.Features.Auth_.Register;
using Kiosk.Application.Payloads.Organization;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Auth)]
public class AuthController(
    Create create,
    Login login
) : ApiController
{
    [HttpPost]
    public async Task<ActionResult<Result<GetTokenPayload>>> Post(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        return response;
    }

    [HttpPost("login")]
    public async Task<ActionResult<Result<GetTokenPayload>>> Login(
        LoginRequest request, CancellationToken cancellationToken
    )
    {
        var response = await login.ExecuteAsync(request, cancellationToken);
        return response;
    }
}
