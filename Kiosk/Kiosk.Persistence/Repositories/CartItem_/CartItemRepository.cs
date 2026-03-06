
﻿using Kiosk.Application.Repository.CartItemRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.CartItem_;

public class CartItemRepository(KioskContext context)
    : BaseRepository<CartItem>(context), ICartItemRepository
{
    
}
