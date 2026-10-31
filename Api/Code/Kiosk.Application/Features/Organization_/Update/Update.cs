using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Organization_.Update;

public class Update(
    IOrganizationService organizationService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await organizationService.Update(request, cancellationToken);
        return response;
    }
}
