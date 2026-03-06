
﻿using Kiosk.Application.Repository.VariantRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Variant_;

public class VariantRepository(KioskContext context)
    : BaseRepository<Variant>(context), IVariantRepository
{
    
}
