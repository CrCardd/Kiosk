
using Kiosk.Api.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
//[Route(APIRoutes.Product)]
public class ProductController : ControllerBase
{
    
    /*
    FORMAT EXAMPLE:
        -------------------------------------------------------------------------
        [Http[METHOD]]
        public async Task<ActionResult<[SERVICE]ProductResponse>> [METHOD](
            [SERVICE]ProductRequest request, CancellationToken cancellationToken
        )
        {
            var response = await mediator.Send(request, cancellationToken);
            return [METHOD](APIRoutes.Categories, response);
        }
        -------------------------------------------------------------------------
    */
}
