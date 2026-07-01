
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Variant_.Delete;
using Kiosk.Application.Features.Variant_.Create;
using Kiosk.Application.Features.Variant_.GetAll;
using Kiosk.Application.Features.Variant_.GetById;
using Kiosk.Application.Features.Variant_.GetByService;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Variant;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Api.Common.Auth;
using Microsoft.AspNetCore.Authorization;
using Kiosk.Api.Controllers.Api;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Variant)]
public class VariantController(
    Create create,
    GetAll getAll,
    GetByService getByService,
    GetById getById,
    Update update,
    Delete delete
) : ApiController
{
    [OrganizationAuth]
    [HttpPost]
    public async Task<ActionResult<GetPayload>> Create(
        [FromBody] CreatePayload request,
        CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> GetAll(
        [FromQuery] bool? available,
        CancellationToken cancellationToken
    )
    {
        var response = await getAll.ExecuteAsync(available, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
    
    [Authorize]
    [HttpGet("service/{serviceId}")]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> GetAll(
        [FromRoute] Guid serviceId,
        CancellationToken cancellationToken
    )
    {
        var response = await getByService.ExecuteAsync(serviceId, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> GetById(
        [FromRoute] Guid id, CancellationToken cancellationToken
    )
    {
        var response = await getById.ExecuteAsync(id, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }

    [OrganizationAuth]
    [HttpPatch("{id}")]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> Update(
        [FromBody] UpdatePayload request,
        [FromRoute] Guid id, 
        CancellationToken cancellationToken
    )
    {
        var response = await update.ExecuteAsync(id, request, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }

    [OrganizationAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<GenericListPayload<GetPayload>>> Delete(
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
