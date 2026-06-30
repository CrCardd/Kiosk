using System.Security.Claims;
using Kiosk.Api.Auth;
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.StartKiosk;
using Kiosk.Application.Features.Code_;
using Kiosk.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Code)]
public class CodeController(
    Create create,
    StartKiosk startKiosk
) : ControllerBase
{

    [OrganizationAuth]
    [HttpPost]
    public async Task<ActionResult<GetTokenPayload>> Create(
        CancellationToken cancellationToken
    )
    {
        var organizationId = User.FindFirst(MyClaims.OrganizationId)!.Value;
        var response = await create.ExecuteAsync(Guid.Parse(organizationId), cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPost("login/{code}")]
    public async Task<ActionResult<GetTokenPayload>> Login(
        [FromRoute] string code, CancellationToken cancellationToken
    )
    {
        var response = await startKiosk.ExecuteAsync(code, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}
