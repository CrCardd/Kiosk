
using Kiosk.Api.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
//[Route(APIRoutes.Price)]
public class PriceController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;
    
    /*
    FORMAT EXAMPLE:
        -------------------------------------------------------------------------
        [Http[METHOD]]
        public async Task<ActionResult<[SERVICE]PriceResponse>> [METHOD](
            [SERVICE]PriceRequest request, CancellationToken cancellationToken
        )
        {
            var response = await mediator.Send(request, cancellationToken);
            return [METHOD](APIRoutes.Categories, response);
        }
        -------------------------------------------------------------------------
    */
}
