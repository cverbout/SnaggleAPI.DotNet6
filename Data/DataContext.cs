using Microsoft.EntityFrameworkCore;


namespace SnaggleAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Snag> Snags { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
