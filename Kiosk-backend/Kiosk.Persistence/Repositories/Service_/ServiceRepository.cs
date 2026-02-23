
using Kiosk.Application.Repository.ServiceRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Service_;

public class ServiceRepository(KioskContext context)
    : BaseRepository<Service>(context), IServiceRepository
{
    
}
