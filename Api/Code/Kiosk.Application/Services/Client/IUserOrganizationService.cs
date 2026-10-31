
using Kiosk.Application.Payloads.UserOrganization;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IUserOrganizationService : IBaseService<UserOrganizationModel, GetPayload>
{
    // Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}