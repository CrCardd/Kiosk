
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Variant_.GetAll;

public class GetAll(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GetAllResponse>> ExecuteAsync(GetAllRequest request, CancellationToken cancellationToken)
    {
        var response = await variantService.GetAll(request.Available, cancellationToken);
        if(!response.IsSuccess)
            return response.Message;
        return new GetAllResponse(response.Value.Count,response.Value);
    }
}
