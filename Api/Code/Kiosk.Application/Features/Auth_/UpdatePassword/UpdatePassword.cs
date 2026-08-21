using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.User;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Features.Auth_.UpdatePassword;

public class UpdatePassword(
    IUserClientService service,

    IApiContext ctx,
    IPasswordService passwordService
) : BaseFeature
{
    public async Task<Result> ExecuteAsync(string newPassword, CancellationToken cancellationToken)
    {
        var user = service.Get(o => o.Id == ctx.UserId);

        var hashPassword = passwordService.Hash(newPassword);
        var update = new UpdatePayload
        {
            Password = new UpdateObject<string?>{HasChanged=true, Value=hashPassword}
        };
        
        var response = await service.Update(update, cancellationToken);


        return Result.Ok();
    }
}
