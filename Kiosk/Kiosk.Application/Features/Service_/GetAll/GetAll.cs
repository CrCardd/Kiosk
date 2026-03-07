
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.GetAll;

public class GetAll(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<BaseResponse<GetAllResponse>> ExecuteAsync(GetAllRequest request, CancellationToken cancellationToken)
    {
        var response = await serviceService.GetAll(request.Available);
        return BaseResponse<GetAllResponse>.Success(new(response));
    }
}
