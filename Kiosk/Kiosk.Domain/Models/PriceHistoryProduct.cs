
﻿namespace Kiosk.Domain.Models;

public class PriceHistoryProduct : BaseModel
{
    //================PROPERTIES================
    public required decimal Price {get;set;}
    
    //================MY-RELATIONS================
    public required Product Product {get;set;}
    public required Guid ProductId {get;set;}

    //================RELATIONS================
}
