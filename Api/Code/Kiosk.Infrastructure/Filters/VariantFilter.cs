using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class VariantFilter
{
    public static void ConfigureVariantFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<VariantModel>(builder =>
    {

        builder.HasQueryFilter(v =>
            context.IsSuperAdmin || v.SegmentId == context.CurrentSegmentId
        );
    });
}
