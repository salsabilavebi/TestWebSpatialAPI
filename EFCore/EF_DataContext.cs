using Microsoft.EntityFrameworkCore;

namespace APIplaces.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }
        

        public DbSet<Place> Places { get; set; }

    }
}
