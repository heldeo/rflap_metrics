using Microsoft.EntityFrameworkCore;

namespace rflap_metrics.Models
{
    public class ExportContext : DbContext
    {
   
        public ExportContext(DbContextOptions<ExportContext> options)
            : base(options)
        {
        }

        public DbSet<Export> Export { get; set; }
    }
}