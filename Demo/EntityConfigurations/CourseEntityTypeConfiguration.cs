using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.EntityConfigurations
{
    public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.Property(pc => pc.Name).IsRequired();

            builder.HasMany(pc => pc.Students)
          .WithOne(pc => pc.Course)
          .HasForeignKey(pc => pc.CourseId)
          .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
