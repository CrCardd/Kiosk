
using Kiosk.Api.Common.Auth;
using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.VariantIngredient_.Create;
using Kiosk.Application.Payloads.VariantIngredient;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;

namespace Kiosk.Api.Controllers.Client;

[ApiController]
[Route(APIRoutes.VariantIngredient)]
public class VariantIngredientController(
    Create create
) : ApiController
{
    [SegmentAuth]
    [HttpPost]
    public async Task<ActionResult<Result<GetPayload>>> Create(
        [FromBody] CreatePayload request,
        CancellationToken cancellationToken
    )
    {
        var response = await create.ExecuteAsync(request, cancellationToken);
        return response;
    }
}
