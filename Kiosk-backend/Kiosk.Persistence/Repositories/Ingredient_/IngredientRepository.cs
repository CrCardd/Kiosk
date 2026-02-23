
using Kiosk.Application.Repository.IngredientRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Ingredient_;

public class IngredientRepository(KioskContext context)
    : BaseRepository<Ingredient>(context), IIngredientRepository
{
    
}
