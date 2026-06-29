
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Service_.Create;
using Kiosk.Application.Features.Service_.GetAll;
using Kiosk.Application.Features.Service_.Update;
using Kiosk.Application.Features.Service_.GetById;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Service;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Features.Service_.Delete;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Service)]
public class ServiceController(
    Create create,
    GetAll getAll,
    GetById getById,
    Update update,
    Delete delete
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GetPayload>> Create(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> GetAll
    (
        [FromQuery] bool? available, CancellationToken cancellationToken
    )
    {
        var response = await getAll.ExecuteAsync(available, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> GetAll
    (
        [FromRoute] Guid id, CancellationToken cancellationToken
    )
    {
        var response = await getById.ExecuteAsync(id, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<GetPayload>> Update
    (
        [FromRoute] Guid id,
        [FromBody] UpdatePayload request,
        CancellationToken cancellationToken
    )
    {
        var response = await update.ExecuteAsync(id, request, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GetPayload>> Delete
    (
        [FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        var response = await delete.ExecuteAsync(id, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }
}
