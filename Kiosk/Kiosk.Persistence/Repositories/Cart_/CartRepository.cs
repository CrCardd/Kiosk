
﻿using Kiosk.Application.Repository.CartRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Cart_;

public class CartRepository(KioskContext context)
    : BaseRepository<Cart>(context), ICartRepository
{
    
}
