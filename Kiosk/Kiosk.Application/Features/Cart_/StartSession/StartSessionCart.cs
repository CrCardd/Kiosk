
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Cart_.StartSession;

public class StartSessionCart(
    ICartService cartService
) : BaseFeature
{
    public async Task<StartSessionCartResponse> ExecuteAsync(StartSessionCartRequest request, CancellationToken cancellationToken)
    {
        await cartService.Start(new(request.Client, request.SessionToken));
        return new();
    }
}
