using Microsoft.EntityFrameworkCore;

namespace rflap_metrics.Models
{
    public class ExportContext : DbContext
    {
        public ExportContext(DbContextOptions<ExportContext> options)
            : base(options)
        {
        }

        public DbSet<ExportContext> Export { get; set; }
    }
}