using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
                    : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoContext).Assembly);

            modelBuilder.UseIdentityAlwaysColumns();
        }
    }
}
