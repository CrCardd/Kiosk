
﻿using Kiosk.Application.Repository.ProductRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Product_;

public class ProductRepository(KioskContext context)
    : BaseRepository<Product>(context), IProductRepository
{
    
}
