
namespace Kiosk.Domain.Models;

public class ProductOrder : BaseModel
{
    //================PROPERTIES================
    public required decimal SnapshotPrice {get;set;}
    //================MY-RELATIONS================
    public required Order Order {get;set;}
    public required Guid OrderId {get;set;}
    public required Product Product {get;set;}
    public required Guid ProductId {get;set;}
    //================RELATIONS================
    
}
