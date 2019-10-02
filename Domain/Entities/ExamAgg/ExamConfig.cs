using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.ExamAgg
{
    public class ExamConfig : IEntityTypeConfiguration<ExamInfo>
    {
        public void Configure(EntityTypeBuilder<ExamInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BeginTime).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(50);
        }
    }
}
