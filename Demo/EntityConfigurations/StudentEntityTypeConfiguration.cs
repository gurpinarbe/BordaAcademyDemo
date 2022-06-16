using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.EntityConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.Property(pc => pc.FirstName).IsRequired();
            builder.Property(pc => pc.LastName).IsRequired();
            builder.Property(pc => pc.StudentNumber);
        }
    }
}
