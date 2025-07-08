using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IPOC.EntityFrameworkCore
{
    public static class IPOCDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IPOCDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IPOCDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
