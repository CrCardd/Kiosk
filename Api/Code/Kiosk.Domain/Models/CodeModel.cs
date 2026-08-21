namespace Kiosk.Domain.Models;

public class CodeModel : BaseModel
{
    //================PROPERTIES================
    public required string Code {get;set;}
    public required DateTime StartDate {get;set;}
    public required DateTime EndDate {get;set;}
    //================MY-RELATIONS================
    public required SegmentModel Segment {get;set;}
    public required Guid SegmentId {get;set;}
    //================RELATIONS================

}