
using System.Security.Claims;
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Auth_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Code)]
public class CodeController(
    StartToken startToken
) : ControllerBase
{

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GetTokenPayload>> Login(
        CancellationToken cancellationToken
    )
    {
        var organizationId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var response = await startToken.ExecuteAsync(Guid.Parse(organizationId), cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}
