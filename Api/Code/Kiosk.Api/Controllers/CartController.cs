
using Kiosk.Api.Controllers.Api;
using Kiosk.Api.Common.Enums;
using Kiosk.Application.Features.Cart_.GetById;
using Kiosk.Application.Features.Cart_.StartSession;
using Kiosk.Application.Payloads.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Application.Services;

namespace Kiosk.Api.Controllers;

[ApiController]
[Route(APIRoutes.Cart)]
public class CartController(
    StartSessionCart startSessionCart,
    GetById getById
) : ApiController
{   
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Result<GetPayload>>> Post(
        CreatePayload request, CancellationToken cancellationToken
    )
    {
        var response = await startSessionCart.ExecuteAsync(request, cancellationToken);
        return response;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetPayload>>> GetById(
        [FromRoute] Guid id, CancellationToken cancellationToken
    )
    {
        var response = await getById.ExecuteAsync(id, cancellationToken);
        return response;
    }
}