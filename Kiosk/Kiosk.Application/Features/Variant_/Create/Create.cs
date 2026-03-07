
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Variant_.Create;

public class Create(
    IVariantService variantService
) : BaseFeature
{
    public async Task<BaseResponse<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var response = await variantService.Create(
            new(
                request.Name, 
                request.Image,
                request.Ingredients ?? 1,
                request.Surpass ?? false,
                request.Available ?? true, 
                request.ServiceId
            ), 
            cancellationToken
        );
        if(response?.Id == null)
            return BaseResponse<CreateResponse>.Fail("Invalid Service Id");
        return BaseResponse<CreateResponse>.Success(new(
            (Guid)response.Id,
            response.Name,
            response.Image,
            response.Available,
            response.Ingredients,
            response.Surpass,
            response.ServiceId
        ));
    }
}
