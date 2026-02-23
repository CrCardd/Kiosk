
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class TokenClassMap
{
    public static void ConfigureTokenTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Token>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(token => token.Id)
            .HasName("token_id");

        builder.ToTable("tb_token");
    });
}
