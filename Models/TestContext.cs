using Microsoft.EntityFrameworkCore;

namespace rflap_metrics.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
         }

        public DbSet<Test> Test { get; set; }
    }
}