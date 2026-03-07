
using Kiosk.Application.Common.Exceptions;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.Update;

public class Update(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<BaseResponse<UpdateResponse>> ExecuteAsync(UpdateRequest request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Update(
            request.Id, 
            new(
                request.Updates.Name, 
                request.Updates.Image, 
                request.Updates.Available
            ), 
            cancellationToken
        );

        if(response == null)
            return BaseResponse<UpdateResponse>.Fail("Invalid Id");

        return BaseResponse<UpdateResponse>.Success(
            new(
                (Guid)response.Id,
                response.Name,
                response.Image,
                response.Available
            )
        );
    }
}
