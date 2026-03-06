
﻿using Kiosk.Application.Repository.PriceHistoryVariantRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.PriceHistoryVariant_;

public class PriceHistoryVariantRepository(KioskContext context)
    : BaseRepository<PriceHistoryVariant>(context), IPriceHistoryVariantRepository
{
    
}
