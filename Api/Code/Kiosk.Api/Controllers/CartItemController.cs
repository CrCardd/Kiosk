
using Kiosk.Api.Common.Auth;
using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.CartItem_.Create;
using Kiosk.Application.Payloads.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.CartItem)]
public class CartItemController(
    Create create
) : ApiController
{
    [KioskAuth]
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
