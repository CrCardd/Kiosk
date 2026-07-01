using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Utils;

namespace Kiosk.Application.Features.Code_;

public class Create(
    ICodeService service,

    IPasswordService passwordService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(Guid organizationId, CancellationToken cancellationToken)
    {
        DateTime endDate;
        try
        {
          var hours = int.Parse(Environment.GetEnvironmentVariable("TOKEN_CODE_DURATION")!);
          endDate = DateTime.UtcNow.AddHours(hours);
        }
        catch
        {
            endDate = DateTime.MaxValue;
        }
        
        var code = RandomCodeGenerator.Generate("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8);
        var payload = new CreatePayload
        {
            Code = passwordService.Hash(code),
            OrganizationId = organizationId,
            StartDate = DateTime.UtcNow,
            EndDate = endDate
        };
        var response = await service.Create(payload, cancellationToken);
        if(!response.IsSuccess)
            return new NotFoundEx(response.Message);

        return new GetTokenPayload{Token = code};
    }
}