
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Cart_.StartSession;

public class StartSessionCart(
    ICartService cartService
) : BaseFeature
{
    public async Task<BaseResponse<StartSessionCartResponse>> ExecuteAsync(StartSessionCartRequest request, CancellationToken cancellationToken)
    {
        var response = await cartService.Start(new(request.Client, request.SessionToken), cancellationToken);

        if(response?.Id == null)
            return BaseResponse<StartSessionCartResponse>.Fail("Invalid data");
        return BaseResponse<StartSessionCartResponse>.Success(new(
            (Guid)response.Id,
            response.SessionToken,
            response.Client
        ));
    }
}
