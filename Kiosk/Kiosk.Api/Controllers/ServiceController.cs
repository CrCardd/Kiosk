
using Kiosk.Api.Enums;
using Kiosk.Application.Features;
using Kiosk.Application.Features.Service_.Create;
using Kiosk.Application.Features.Service_.GetAll;
using Kiosk.Application.Features.Service_.Update;
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
    public async Task<ActionResult<CreateResponse>> Create(
        CreateRequest request, CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetAllResponse>> GetAll
    (
        [FromQuery] bool? available, CancellationToken cancellationToken
    )
    {
        var response = await getAll.ExecuteAsync(new(available), cancellationToken);
        return Ok(response);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateResponse>> Update
    (
        [FromBody] UpdateRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await update.ExecuteAsync(request, cancellationToken);
        if(response.Successfull)
            return Ok(response);
        return BadRequest(response);
    }
}
