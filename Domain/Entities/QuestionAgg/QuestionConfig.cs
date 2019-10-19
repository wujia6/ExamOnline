using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.QuestionAgg
{
    public class QuestionInfoConfig : IEntityTypeConfiguration<QuestionInfo>
    {
        public void Configure(EntityTypeBuilder<QuestionInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Category).IsRequired();
            builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Contents).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Answer).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
            //one to many
            builder.HasOne(s => s.ExamInfomation).WithMany(m => m.QuestionInfomations);
        }
    }
}
