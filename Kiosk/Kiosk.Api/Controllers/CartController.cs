
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
    /*
    FORMAT EXAMPLE:
        -------------------------------------------------------------------------
        [Http[METHOD]]
        public async Task<ActionResult<[SERVICE]CartResponse>> [METHOD](
            [SERVICE]CartRequest request, CancellationToken cancellationToken
        )
        {
            var response = await mediator.Send(request, cancellationToken);
            return [METHOD](APIRoutes.Categories, response);
        }
        -------------------------------------------------------------------------
    */
    
        [HttpPost]
        public async Task<ActionResult<StartSessionCartResponse>> Post(
            StartSessionCartRequest request, CancellationToken cancellationToken
        )
        {
            var response = await startSessionCart.ExecuteAsync(request, cancellationToken);
            return Ok(response);
        }
}
