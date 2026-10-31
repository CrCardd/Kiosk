namespace Kiosk.Domain.Models;

public class CodeModel : BaseModelWithSegment
{
    //================PROPERTIES================
    public required string Code {get;set;}
    public required DateTime StartDate {get;set;}
    public required DateTime EndDate {get;set;}
    //================MY-RELATIONS================
    
    //================RELATIONS================

}