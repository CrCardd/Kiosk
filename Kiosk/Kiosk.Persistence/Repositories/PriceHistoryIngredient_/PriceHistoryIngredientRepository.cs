
﻿using Kiosk.Application.Repository.PriceHistoryIngredientRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.PriceHistoryIngredient_;

public class PriceHistoryIngredientRepository(KioskContext context)
    : BaseRepository<PriceHistoryIngredient>(context), IPriceHistoryIngredientRepository
{
    
}
