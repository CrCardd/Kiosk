using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Auth_.Create;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;
using Kiosk.Application.Features.Auth_.Provider;
using Kiosk.Application.Features.Auth_.ForgotPassword;
using Kiosk.Api.Config;
using Kiosk.Application.Features.Organization_.UpdatePassword;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Api.Common.Auth;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Auth)]
public class AuthController(
    Login login,
    ForgotPassword forgotPassword,
    UpdatePassword updatePassword,
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

    [HttpPost("forgot-password/{email}")]
    public async Task<ActionResult<Result>> ForgotPassword(
        [FromRoute] string email, CancellationToken cancellationToken
    )
    {
        var response = await forgotPassword.ExecuteAsync(email, cancellationToken);
        return response;
    }

    [PasswordAuth]
    [HttpPatch("update-password/{password}")]
    public async Task<ActionResult<Result>> UpdatePassword(
        [FromRoute] string password, CancellationToken cancellationToken
    )
    {
        var response = await updatePassword.ExecuteAsync(User.OrganizationId(), password, cancellationToken);
        return response;
    }
}
