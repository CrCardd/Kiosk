
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Service_.Create;
using Kiosk.Application.Features.Service_.GetAll;
using Kiosk.Application.Features.Service_.Update;
using Kiosk.Application.Features.Service_.GetById;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Service;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Features.Service_.Delete;
using Kiosk.Api.Common.Auth;
using Microsoft.AspNetCore.Authorization;
using Kiosk.Api.Controllers.Api;
using Kiosk.Application.Services;

namespace Kiosk.Api.Controllers.Client;

[ApiController]
[Route(APIRoutes.Service)]
public class ServiceController(
    Create create,
    GetAll getAll,
    GetById getById,
    Update update,
    Delete delete
) : ApiController
{
    [OrganizationAuth]
    [HttpPost]
    public async Task<ActionResult<Result<GetPayload>>> Create(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        return response;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Result<GenericListPayload<GetPayload>>>> GetAll
    (
        [FromQuery] bool? available, CancellationToken cancellationToken
    )
    {
        var response = await getAll.ExecuteAsync(available, cancellationToken);
        return response;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetPayload>>> GetById
    (
        [FromRoute] Guid id, CancellationToken cancellationToken
    )
    {
        var response = await getById.ExecuteAsync(id, cancellationToken);
        return response;
    }

    [OrganizationAuth]
    [HttpPatch]
    public async Task<ActionResult<Result<GetPayload>>> Update
    (
        [FromBody] UpdatePayload request,
        CancellationToken cancellationToken
    )
    {
        var response = await update.ExecuteAsync(request, cancellationToken);
        return response;
    }

    [OrganizationAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Result<GetPayload>>> Delete
    (
        [FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        var response = await delete.ExecuteAsync(id, cancellationToken);
        return response;
    }
}
