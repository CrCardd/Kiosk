
using Kiosk.Api.Enums;
using Kiosk.Application.Features;
using Kiosk.Application.Features.Service_.Create;
using Kiosk.Application.Features.Service_.GetAll;
using Kiosk.Application.Features.Service_.Update;
using Kiosk.Domain.Payloads.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Service)]
public class ServiceController(
    Create create,
    GetAll getAll,
    Update update
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
    public async Task<ActionResult<GetAllResponse>> GetAll
    (
        [FromQuery] bool? available, CancellationToken cancellationToken
    )
    {
        var response = await getAll.ExecuteAsync(new(available), cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateResponse>> Update
    (
        [FromBody] UpdateRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await update.ExecuteAsync(request, cancellationToken);
        if(response.IsSuccess)
            return Ok(response);
        return BadRequest(response);
    }
}
