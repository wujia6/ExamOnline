using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.ExamAgg
{
    public class ExaminationConfig : IEntityTypeConfiguration<ExaminationInfo>
    {
        public void Configure(EntityTypeBuilder<ExaminationInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BeginTime).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
        }
    }
}
