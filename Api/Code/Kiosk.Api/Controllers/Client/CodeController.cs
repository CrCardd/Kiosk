using Kiosk.Api.Common.Auth;
using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.StartKiosk;
using Kiosk.Application.Features.Code_;
using Kiosk.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;

namespace Kiosk.Api.Controllers.Client;

[ApiController]
[Route(APIRoutes.Code)]
public class CodeController(
    Create create,
    StartKiosk startKiosk
) : ApiController
{

    [SegmentAuth]
    [HttpPost]
    public async Task<ActionResult<Result<GetTokenPayload>>> Create(
        CancellationToken cancellationToken
    )
    {
        var segmentId = User.FindFirst(MyClaims.SegmentId)!.Value;
        var response = await create.ExecuteAsync(Guid.Parse(segmentId), cancellationToken);
        return response;
    }

    [HttpPost("login/{code}")]
    public async Task<ActionResult<Result<GetTokenPayload>>> Login(
        [FromRoute] string code, CancellationToken cancellationToken
    )
    {
        var response = await startKiosk.ExecuteAsync(code, cancellationToken);
        return response;
    }
}
