using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Airbnb.Infra.Repository.Map;

public class ListingRuleMap : IEntityTypeConfiguration<ListingRule>
{
    public void Configure(EntityTypeBuilder<ListingRule> builder)
    {
        builder.ToTable("Listing", "Rule");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ListingId)
            .IsRequired();

        builder.HasOne(x => x.RuleCatalog)
            .WithMany()
            .HasForeignKey(x => x.RuleCatalogId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Parameters)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v) ?? new())
            .HasColumnType("nvarchar(max)")
            .HasColumnName("ParametersJson");
    }
}