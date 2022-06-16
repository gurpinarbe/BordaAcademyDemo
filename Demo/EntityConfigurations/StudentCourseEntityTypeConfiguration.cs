using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.EntityConfigurations
{
    public class StudentCourseEntityTypeConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable(nameof(StudentCourse));
            
            builder.Property(pc => pc.StudentId).IsRequired();
            builder.Property(pc => pc.CourseId).IsRequired();
        }
    }
}
