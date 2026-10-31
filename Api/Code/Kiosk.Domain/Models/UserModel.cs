
namespace Kiosk.Domain.Models;

public class UserModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Email {get;set;}
    public required string Password {get;set;}
    //================MY-RELATIONS================
    //================RELATIONS================
    public ICollection<UserOrganizationModel> UserOrganizations {get;set;} = [];
    public ICollection<UserSegmentModel> UserSegments {get;set;} = [];
}