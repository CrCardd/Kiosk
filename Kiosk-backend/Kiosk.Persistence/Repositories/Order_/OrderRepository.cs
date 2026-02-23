
using Kiosk.Application.Repository.OrderRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Order_;

public class OrderRepository(KioskContext context)
    : BaseRepository<Order>(context), IOrderRepository
{
    
}
