using Microsoft.EntityFrameworkCore;
using SnaggleAPI.Models;

namespace SnaggleAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Snag> Snags => Set<Snag>();

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<User> Users => Set<User>();
       
    }


}
