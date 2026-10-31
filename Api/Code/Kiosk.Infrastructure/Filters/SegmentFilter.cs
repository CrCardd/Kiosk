using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Filters;

public static class SegmentFilter
{
    public static void ConfigureSegmentFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<SegmentModel>(builder =>
    {
        builder.HasQueryFilter(s =>
            context.IsSuperAdmin 
            || s.Organization == null 
            || s.OrganizationId == context.CurrentSegmentId
        );
    });
}
