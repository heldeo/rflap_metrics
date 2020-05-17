using Microsoft.EntityFrameworkCore;

namespace rflap_metrics.Models
{
    public class TestResultContext : DbContext
    {
        public TestResultContext(DbContextOptions<TestResultContext> options)
            : base(options)
        {
        }

        public DbSet<TestResult> TestResult { get; set; }
    }
}