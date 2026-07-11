
using Kiosk.Application.Payloads.Cart;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Cart_.GetById;

public class GetById(
    ICartClientService cartService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await cartService.GetById(id, cancellationToken);
        return response;
    }
}
