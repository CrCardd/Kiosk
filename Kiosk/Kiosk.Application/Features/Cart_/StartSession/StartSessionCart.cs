
using Kiosk.Domain.Payloads.Cart;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Cart_.StartSession;

public class StartSessionCart(
    ICartService cartService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await cartService.Start(request, cancellationToken);
        return response;
    }
}
