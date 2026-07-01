
using Kiosk.Api.Common.Auth;
using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Ingredient_.Create;
using Kiosk.Application.Payloads.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Ingredient)]
public class IngredientController(
    Create create
) : ApiController
{
    [OrganizationAuth]
    [HttpPost]
    public async Task<ActionResult<GetPayload>> Create(
        [FromBody] CreatePayload request,
        CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        if(!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}
