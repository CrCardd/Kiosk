using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class IngredientFilter
{
    public static void ConfigureIngredientFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<IngredientModel>(builder =>
    {

        builder.HasQueryFilter(i =>
            context.IsSuperAdmin || i.SegmentId == context.CurrentSegmentId
        );
    });
}
