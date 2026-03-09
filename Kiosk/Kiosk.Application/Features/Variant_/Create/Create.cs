
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Variant_.Create;

public class Create(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var response = await variantService.Create(
            new(
                request.Name, 
                request.Price,
                request.Image,
                request.Ingredients ?? 1,
                request.Surpass ?? false,
                request.Available ?? true, 
                request.ServiceId
            ), 
            cancellationToken
        );
        if(!response.IsSuccess)
            return response.Message;
        return new CreateResponse(
            response.Value.Id,
            response.Value.Name,
            response.Value.Price,
            response.Value.Image,
            response.Value.Available,
            response.Value.Ingredients,
            response.Value.Surpass,
            response.Value.ServiceId
        );
    }
}
