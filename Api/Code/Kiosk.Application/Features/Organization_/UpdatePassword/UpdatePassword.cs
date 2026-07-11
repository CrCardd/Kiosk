using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Features.Organization_.UpdatePassword;

public class UpdatePassword(
    IOrganizationClientService service,

    IApiContext ctx,
    IPasswordService passwordService
) : BaseFeature
{
    public async Task<Result> ExecuteAsync(string newPassword, CancellationToken cancellationToken)
    {
        var organization = service.Get(o => o.Id == ctx.OrganizationId);

        var hashPassword = passwordService.Hash(newPassword);
        var update = new UpdatePayload
        {
            Password = new UpdateObject<string?>{HasChanged=true, Value=hashPassword}
        };
        
        var response = await service.Update(update, cancellationToken);


        return Result.Ok();
    }
}
