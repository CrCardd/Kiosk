using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.Register;
using Kiosk.Application.Payloads.Organization;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;
using Kiosk.Application.Features.AuthCode_.CreateAccount;
using Kiosk.Api.Common.Auth;
using Kiosk.Application.Features.AuthCode_.Validate;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Api.Controllers.Client;

[ApiController]
[Route(APIRoutes.Register)]
public class RegisterController(
    Create create,

    CreateAccount createAccount,
    Validate validate,

    IApiContext ctx
) : ApiController
{
    [RegisterAuth]
    [HttpPost]
    public async Task<ActionResult<Result<GetTokenPayload>>> Post(
        CreateRequest request, CancellationToken cancellationToken
    )
    {
        var payload = new CreatePayload
        {
            Email = ctx.Email,
            Name = request.Name,
            Password = request.Password
        };
        var response = await create.ExecuteAsync(payload, cancellationToken);
        return response;
    }

    [HttpPost("code-create/{email}")]
    public async Task<ActionResult<Result>> PostAuthCode(
        [FromRoute] string email, CancellationToken cancellationToken
    )
    {
        var response = await createAccount.ExecuteAsync(email, cancellationToken);
        return response;
    }
    
    [HttpPost("code-verify")]
    public async Task<ActionResult<Result<GetTokenPayload>>> ValidateAuthCode(
        ValidateRequest request, CancellationToken cancellationToken
    )
    {
        var response = await validate.ExecuteAsync(request, cancellationToken);
        return response;
    }

}
