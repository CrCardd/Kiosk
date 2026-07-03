
using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Models;

public class ProviderModel : BaseModel
{
    //================PROPERTIES================
    public required string Subject {get;set;}
    public required string Email {get;set;}
    public required string Name {get;set;}
    public required string Picture {get;set;}
    public required ProviderType Type {get;set;}
    //================MY-RELATIONS================
    public required OrganizationModel Organization {get;set;}
    public required Guid OrganizationId {get;set;}
    //================RELATIONS================
}
