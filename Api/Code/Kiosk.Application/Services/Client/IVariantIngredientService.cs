
using Kiosk.Application.Payloads.VariantIngredient;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IVariantIngredientService : IBaseService<VariantIngredientModel, GetPayload>
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}