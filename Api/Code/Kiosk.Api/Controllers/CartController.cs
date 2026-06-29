
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Cart_.GetById;
using Kiosk.Application.Features.Cart_.StartSession;
using Kiosk.Application.Payloads.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Cart)]
public class CartController(
    StartSessionCart startSessionCart,
    GetById getById
) : ControllerBase
{   
    [HttpPost]
    public async Task<ActionResult<GetPayload>> Post(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await startSessionCart.ExecuteAsync(request, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPayload>> GetById(
        [FromRoute] Guid id, CancellationToken cancellationToken
    )
    {
        var response = await getById.ExecuteAsync(id, cancellationToken);
        if(!response.IsSuccess)
            return NotFound(response);
        return Ok(response);
    }
}