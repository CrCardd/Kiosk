using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;

namespace Kiosk.Application.Features.Organization_.UpdatePassword;

public class UpdatePassword(
    IOrganizationService service,

    IPasswordService passwordService
) : BaseFeature
{
    public async Task<Result> ExecuteAsync(Guid organizationId, string newPassword, CancellationToken cancellationToken)
    {
        var organization = service.Get(o => o.Id == organizationId);

        var hashPassword = passwordService.Hash(newPassword);
        var update = new UpdatePayload
        {
            Id = organization.Id,
            Password = new UpdateObject<string?>{HasChanged=true, Value=hashPassword}
        };
        
        var response = await service.Update(update, cancellationToken);


        return Result.Ok();
    }
}
