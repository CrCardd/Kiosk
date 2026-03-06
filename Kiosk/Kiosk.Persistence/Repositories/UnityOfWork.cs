
using System.ComponentModel;
using Kiosk.Application.Repository;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Repositories;

public class UnitOfWork(KioskContext ctx) : IUnitOfWork
{
    private readonly KioskContext context = ctx;

    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}
