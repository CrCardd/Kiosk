namespace Kiosk.Domain.Models;

public class OrganizationModel : BaseModel
{
    
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Password {get;set;}

    //================MY-RELATIONS================

    //================RELATIONS================
    public ICollection<CodeModel> Codes {get;set;} = [];
}