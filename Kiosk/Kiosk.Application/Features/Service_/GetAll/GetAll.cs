
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Service;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.GetAll;

public class GetAll(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(bool? available, CancellationToken cancellationToken)
    {
        var response = await serviceService.GetAll(available, cancellationToken);
        if(!response.IsSuccess)
            return response.Message;
        return response.Value;
    }
}
