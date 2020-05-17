using Microsoft.EntityFrameworkCore;

namespace rflap_metrics.Models
{
    public class ExportContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
}
        public ExportContext(DbContextOptions<ExportContext> options)
            : base(options)
        {
        }

        public DbSet<ExportContext> Export { get; set; }
    }
}