using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        var readOnlyDictComparer = new ValueComparer<IReadOnlyDictionary<string, string>>(
            (d1, d2) => d1 != null && d2 != null && d1.Count == d2.Count && !d1.Except(d2).Any(),
            d => d.Aggregate(0, (a, v) => HashCode.Combine(a, v.Key.GetHashCode(), v.Value.GetHashCode())),
            d => d.ToDictionary(e => e.Key, e => e.Value)
        );


        builder.Property(x => x.Parameters)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v) ?? new())
            .HasColumnType("nvarchar(max)")
            .HasColumnName("ParametersJson")
            .Metadata.SetValueComparer(readOnlyDictComparer);
    }
}