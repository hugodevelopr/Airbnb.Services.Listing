using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map;

public class RuleParameterDefinitionMap : IEntityTypeConfiguration<RuleParameterDefinition>
{
    public void Configure(EntityTypeBuilder<RuleParameterDefinition> builder)
    {
        builder.ToTable("ParameterDefinition", "Rule");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DefaultValue)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.HasOne(x => x.RuleCatalog)
            .WithMany(rc => rc.ParameterDefitions)
            .HasForeignKey(x => x.RuleCatalogId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}