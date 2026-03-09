
using Kiosk.Api.Enums;
using Kiosk.Application.Features.VariantIngredient_.Create;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.VariantIngredient)]
public class VariantIngredientController(
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
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}
