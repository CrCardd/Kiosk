using Kiosk.Application.Payloads.Segment;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Segment_.Create;

public class Create(
    ISegmentService segmentService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await segmentService.Create(request, cancellationToken);
        return response;
    }
}