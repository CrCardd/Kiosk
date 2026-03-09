
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.Create;

public class Create(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Create(new(request.Name,request.Image,request.Available), cancellationToken);

        if(!response.IsSuccess)
            return response.Message;
        return new CreateResponse(
            response.Value.Id,
            response.Value.Name,
            response.Value.Image,
            response.Value.Available
        );
    }
}
