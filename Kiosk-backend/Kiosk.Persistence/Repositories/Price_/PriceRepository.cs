
using Kiosk.Application.Repository.PriceRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Price_;

public class PriceRepository(KioskContext context)
    : BaseRepository<Price>(context), IPriceRepository
{
    
}
