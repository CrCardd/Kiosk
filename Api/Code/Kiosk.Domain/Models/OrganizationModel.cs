namespace Kiosk.Domain.Models;

public class OrganizationModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    //================MY-RELATIONS================
    //================RELATIONS================
    public ICollection<SegmentModel> Segments {get;set;} = [];
    public ICollection<UserOrganizationModel> UserOrganizations {get;set;} = [];
}