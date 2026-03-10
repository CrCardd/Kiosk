
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Variant_.Create;
using Kiosk.Application.Features.Variant_.GetAll;
using Kiosk.Application.Features.Variant_.GetByService;
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Variant;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Variant)]
public class VariantController(
    Create create,
    GetAll getAll,
    GetByService getByService
) : ControllerBase
{
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
}
