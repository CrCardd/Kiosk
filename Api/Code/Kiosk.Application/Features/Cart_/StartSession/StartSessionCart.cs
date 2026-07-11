
using Kiosk.Application.Payloads.Cart;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Cart_.StartSession;

public class StartSessionCart(
    ICartClientService cartService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await cartService.Start(request, cancellationToken);
        return response;
    }
}
