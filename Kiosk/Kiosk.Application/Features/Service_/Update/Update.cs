
using Kiosk.Application.Common.Exceptions;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.Update;

public class Update(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<UpdateResponse>> ExecuteAsync(UpdateRequest request, CancellationToken cancellationToken)
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

        if(!response.IsSuccess)
            return response.Message;
        return new UpdateResponse(
            response.Value.Id,
            response.Value.Name,
            response.Value.Image,
            response.Value.Available
        );
    }
}
