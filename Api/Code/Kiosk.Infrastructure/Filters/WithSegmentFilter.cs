using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Filters;

public static class WithSegmentFilter
{
    public static void ConfigureWithSegmentFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<BaseModelWithSegment>(builder =>
    {
        builder.HasQueryFilter(s =>
            context.IsSuperAdmin 
            || s.Segment == null 
            || s.SegmentId == context.CurrentSegmentId
        );
    });
}
