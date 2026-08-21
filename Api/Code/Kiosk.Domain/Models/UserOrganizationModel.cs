using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Models;

public class UserOrganizationModel : BaseModel
{
    //================PROPERTIES================
    public required OrganizationRole Roles {get;set;}
    //================MY-RELATIONS================
    public required OrganizationModel Organization {get;set;}
    public required Guid OrganizationId {get;set;}
    public required UserModel User {get;set;}
    public required Guid UserId {get;set;}
    //================RELATIONS================
}