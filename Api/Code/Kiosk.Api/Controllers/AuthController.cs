using Kiosk.Api.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.Create;
using Kiosk.Application.Features.Auth_.Register;
using Kiosk.Application.Payloads.Organization;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Auth)]
public class AuthController(
    Create create,
    Login login
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GetTokenPayload>> Post(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<GetTokenPayload>> Login(
        LoginRequest request, CancellationToken cancellationToken
    )
    {
        var response = await login.ExecuteAsync(request, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}
