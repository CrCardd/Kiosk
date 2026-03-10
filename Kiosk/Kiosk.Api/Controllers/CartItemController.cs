
using Kiosk.Api.Enums;
using Kiosk.Application.Features.CartItem_.Create;
using Kiosk.Domain.Payloads.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.CartItem)]
public class CartItemController(
    Create create
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GetPayload>> Post(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}
