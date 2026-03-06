
﻿namespace Kiosk.Domain.Models;

public class Product : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required bool Available {get;set;}
    public required int Quantity {get;set;}

    //================MY-RELATIONS================
    public required Service Service {get;set;}
    public required Guid ServiceId{get;set;}

    //================RELATIONS================
    public ICollection<PriceHistoryProduct> PriceHistoryProducts {get;set;} = [];
    public ICollection<CartItem> CartItems {get;set;} = [];
}
