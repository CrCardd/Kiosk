using Kiosk.Api.Common.Enums;
using Kiosk.Api.Controllers.Api;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Features.Organization_.Create;
using Kiosk.Application.Features.Organization_.Open;
using Kiosk.Application.Features.Organization_.Update;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers.Client;

[ApiController]
[Route(APIRoutes.Organization)]
public class OrganizationController(
    IApiContext ctx,

    Create create,
    Update update,
    Open open
) : ApiController
{
    [HttpPost]
    public async Task<ActionResult<Result<GetPayload>>> Create(
        [FromBody] CreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var userId = ctx.UserId;

        var payload = new CreatePayload
        {
            Name = request.Name,
            CreatedBy = (Guid)userId!
        };

        var response = await create.ExecuteAsync(payload, cancellationToken);
        return response;
    }

    [HttpPut]
    public async Task<ActionResult<Result<GetPayload>>> Update(
        [FromBody] UpdatePayload request,
        CancellationToken cancellationToken
    )
    {
        var response = await update.ExecuteAsync(request, cancellationToken);
        return response;
    }

    [HttpGet("open/{Id:guid}")]
    public async Task<ActionResult<Result<GetTokenPayload>>> Open(
        [FromRoute] Guid Id,
        CancellationToken cancellationToken
    )
    {
        var payload = new OpenRequest
        {
            Email = ctx.Email!,
            UserId = (Guid)ctx.UserId!,
            OrganizationId = Id,
            ExpiresAt = (DateTimeOffset)ctx.ExpiresAt!
        };
        var response = await open.ExecuteAsync(payload, cancellationToken);
        return response;
    }
}
