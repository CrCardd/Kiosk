
﻿using Kiosk.Application.Repository.PriceHistoryProductRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.PriceHistoryProduct_;

public class PriceHistoryProductRepository(KioskContext context)
    : BaseRepository<PriceHistoryProduct>(context), IPriceHistoryProductRepository
{
    
}
