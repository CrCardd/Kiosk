
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Cart_.StartSession;
using Kiosk.Domain.Payloads.Cart;
using Kiosk.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Cart)]
public class CartController(
    StartSessionCart startSessionCart
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
}