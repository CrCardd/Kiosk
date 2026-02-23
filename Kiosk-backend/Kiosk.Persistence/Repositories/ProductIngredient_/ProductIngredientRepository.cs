
using Kiosk.Application.Repository.ProductIngredientRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.ProductIngredient_;

public class ProductIngredientRepository(KioskContext context)
    : BaseRepository<ProductIngredient>(context), IProductIngredientRepository
{
    
}
