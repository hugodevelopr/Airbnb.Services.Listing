using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map;

public class RuleCatalogMap : IEntityTypeConfiguration<RuleCatalog>
{
    public void Configure(EntityTypeBuilder<RuleCatalog> builder)
    {
        builder.ToTable("RuleCatalog", "Listing");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Key)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.DescriptionTemplate)
            .HasMaxLength(1000);

        builder.HasMany<RuleParameterDefinition>()
            .WithOne()
            .HasForeignKey(x => x.RuleCatalogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}