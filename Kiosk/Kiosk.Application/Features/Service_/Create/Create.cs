
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.Create;

public class Create(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<BaseResponse<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Create(new(request.Name,request.Image,request.Available), cancellationToken);

        if(response?.Id == null)
            return BaseResponse<CreateResponse>.Fail("Invalid data");
        return BaseResponse<CreateResponse>.Success(new(
            (Guid)response.Id,
            response.Name,
            response.Image,
            response.Available
        ));
    }
}
