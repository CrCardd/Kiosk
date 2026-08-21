using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Utils;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Code_;

public class Create(
    ICodeClientService service,

    IPasswordService passwordService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(Guid segmentId, CancellationToken cancellationToken)
    {
        DateTime endDate;
        try
        {
          var minutes = int.Parse(Environment.GetEnvironmentVariable("INTERNAL_TOKEN_CODE_DURATION")!);
          endDate = DateTime.UtcNow.AddMinutes(minutes);
        }
        catch
        {
            endDate = DateTime.MaxValue;
        }
        
        var code = RandomCodeGenerator.Generate("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8);
        var payload = new CreatePayload
        {
            Code = passwordService.Hash(code),
            StartDate = DateTime.UtcNow,
            EndDate = endDate
        };
        var response = await service.Create(payload, cancellationToken);
        if(!response.IsSuccess)
            throw new NotFoundEx(response.Message);

        return new GetTokenPayload{Token = code};
    }
}