using Applebrie.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using static Applebrie.IntegrationTests.TestConstants;

namespace Applebrie.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected static ApplebrieDbContext GivenGlobalAppDbContext(bool beginTransaction = true)
        {
            var context = new ApplebrieDbContext(new DbContextOptionsBuilder()
                .UseSqlServer(AppContext.ConnectionString)
                .Options);
            if (beginTransaction)
                context.Database.BeginTransaction();
            return context;
        }

        private static SqlConnectionStringBuilder AppContext =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = TestDbName,
                IntegratedSecurity = true
            };
    }
}
