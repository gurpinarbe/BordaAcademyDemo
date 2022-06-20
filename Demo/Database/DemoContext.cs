using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database
{
    public class DemoContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DemoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder
                .UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoContext).Assembly);

            modelBuilder.UseIdentityAlwaysColumns();
        }
    }
}
