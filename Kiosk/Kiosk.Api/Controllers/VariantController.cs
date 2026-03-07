
using Kiosk.Api.Enums;
using Kiosk.Application.Features.Variant_.Create;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Variant)]
public class VariantController(
    Create create
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateResponse>> Create(
        [FromBody] CreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        if(!response.Successfull)
            BadRequest(response);
        return Ok(response);
    }
}
