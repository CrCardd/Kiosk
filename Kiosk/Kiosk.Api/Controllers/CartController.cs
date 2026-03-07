
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Cart_.StartSession;
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
        public async Task<ActionResult<StartSessionCartResponse>> Post(
            StartSessionCartRequest request, CancellationToken cancellationToken
        )
        {
            var response = await startSessionCart.ExecuteAsync(request, cancellationToken);
            return Ok(response);
        }
}
