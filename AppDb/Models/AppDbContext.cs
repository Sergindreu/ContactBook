using Microsoft.EntityFrameworkCore;

namespace AppDb.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource = App.db");

        public DbSet<Contacts> Contacts { get; set; }


    }
}
