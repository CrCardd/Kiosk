
using Kiosk.Application.Payloads.CartItem;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.CartItem_.Create;

public class Create(
    ICartItemService cartItemService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await cartItemService.Create(request,cancellationToken);
        return response;
    }
}
