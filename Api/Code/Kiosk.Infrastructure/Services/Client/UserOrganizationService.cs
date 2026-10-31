using Kiosk.Application.Payloads.UserOrganization;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;

namespace Kiosk.Infrastructure.Services.Client;

public class UserOrganizationService(
    KioskContext context
) : BaseService<UserOrganizationModel, GetPayload>(context, "userOrganization"), 
    IUserOrganizationService
{
}