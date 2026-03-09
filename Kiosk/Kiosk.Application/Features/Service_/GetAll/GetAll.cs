
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.GetAll;

public class GetAll(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GetAllResponse>> ExecuteAsync(GetAllRequest request, CancellationToken cancellationToken)
    {
        var response = await serviceService.GetAll(request.Available, cancellationToken);
        if(!response.IsSuccess)
            return response.Message;
        return new GetAllResponse(response.Value);
    }
}
