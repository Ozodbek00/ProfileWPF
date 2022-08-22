using Microsoft.EntityFrameworkCore;
using ProfilesWpf.Domain.Entities;

namespace ProfilesWpf.Data.Contexts
{
    public class ProfilesWpfDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;" +
                "Port=5432;" +
                "Database=StudentDatabase;" +
                "Username=postgres;" +
                "Password=mypost");
        }
    }
}
