
using Kiosk.Application.Payloads.Ingredient;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Client;

public interface IIngredientClientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}