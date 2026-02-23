
using Kiosk.Application.Repository.TokenRepository;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories.Token_;

public class TokenRepository(KioskContext context)
    : BaseRepository<Token>(context), ITokenRepository
{
    
}
