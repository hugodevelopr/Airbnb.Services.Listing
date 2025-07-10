using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map.System;

public class LocalizeMessageMap : IEntityTypeConfiguration<LocalizeMessage>
{
    public void Configure(EntityTypeBuilder<LocalizeMessage> builder)
    {
        builder.ToTable("LocalizeMessage", "System");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Key)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.MessageTemplate)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Language)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasIndex(x => x.Key);

    }
}