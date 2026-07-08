using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.Register;
using Kiosk.Application.Payloads.Organization;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;
using Kiosk.Application.Features.AuthCode_.CreateAccount;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Register)]
public class RegisterController(
    Create create,
    CreateAccount createAccount
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

    [HttpPost("code")]
    public async Task<ActionResult<Result<GetTokenPayload>>> PostAuthCode(
        [FromQuery] string email, CancellationToken cancellationToken
    )
    {
        var response = await createAccount.ExecuteAsync(email, cancellationToken);
        return response;
    }

}
