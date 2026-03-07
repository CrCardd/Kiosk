using Kiosk.Domain.Payloads.Models;

namespace Kiosk.Domain.Services;

public interface IIngredientService : IBaseService
{
    public Task<IngredientPayload?> Create(IngredientPayload payload, CancellationToken cancellationToken);
}