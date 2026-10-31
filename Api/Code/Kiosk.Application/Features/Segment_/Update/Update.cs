using Kiosk.Application.Payloads.Segment;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Segment_.Update;

public class Update(
    ISegmentService segmentService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await segmentService.Update(request, cancellationToken);
        return response;
    }
}
