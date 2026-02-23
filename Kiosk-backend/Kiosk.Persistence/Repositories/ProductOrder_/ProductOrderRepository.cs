
using Kiosk.Application.Repository.ProductOrderRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.ProductOrder_;

public class ProductOrderRepository(KioskContext context)
    : BaseRepository<ProductOrder>(context), IProductOrderRepository
{
    
}
