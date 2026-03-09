
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Cart_.StartSession;

public class StartSessionCart(
    ICartService cartService
) : BaseFeature
{
    public async Task<Result<StartSessionCartResponse>> ExecuteAsync(StartSessionCartRequest request, CancellationToken cancellationToken)
    {
        var response = await cartService.Start(new(request.Client, request.SessionToken), cancellationToken);

        if(!response.IsSuccess)
            return response.Message;
        return new StartSessionCartResponse(
            response.Value.Id,
            response.Value.SessionToken,
            response.Value.Client
        );
    }
}
