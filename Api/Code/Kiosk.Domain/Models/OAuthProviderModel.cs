
using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Models;

public class OAuthProviderModel : BaseModel
{
    //================PROPERTIES================
    public required string Subject {get;set;}
    public required string Email {get;set;}
    public required string Name {get;set;}
    public required string Picture {get;set;}
    public required OAuthProviderType Type {get;set;}
    //================MY-RELATIONS================
    
    //================RELATIONS================
}
