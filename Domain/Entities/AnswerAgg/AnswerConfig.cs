﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.AnwserAgg
{
    public class AnswerInfoConfig : IEntityTypeConfiguration<AnswerInfo>
    {
        public void Configure(EntityTypeBuilder<AnswerInfo> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Result).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Score).IsRequired();
            builder.HasOne(e => e.ExamInfo).WithMany(m => m.AnswerInfos);
            builder.HasOne(s => s.Student).WithMany(m => m.AnswerInfos);
        }
    }
}
