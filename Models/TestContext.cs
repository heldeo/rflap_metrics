using Microsoft.EntityFrameworkCore;

namespace toDoApi.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public DbSet<TestContext> Test { get; set; }
    }
}