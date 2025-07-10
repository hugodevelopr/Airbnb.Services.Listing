using System.Text.Json;
using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map;

public class AvailabilityMap : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.ToTable("Availability", "Listing");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(x => x.Listing)
            .WithOne(l => l.Availability)
            .HasForeignKey<Availability>(x => x.ListingId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CheckInTime)
            .HasConversion(
                x => x.ToString("HH:mm"),
                x => TimeOnly.Parse(x))
            .HasMaxLength(5);

        builder.Property(x => x.CheckOutTime)
            .HasConversion(
                x => x.ToString("HH:mm"),
                x => TimeOnly.Parse(x))
            .HasMaxLength(5);

        builder.Property(x => x.MinimumNights)
            .IsRequired();

        builder.Property(x => x.MaximumNights)
            .IsRequired();

        var datelistComparer = new ValueComparer<List<DateOnly>>(
            (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

        builder.Property(x => x.BlockedDates)
            .HasConversion(
                x => JsonSerializer.Serialize(x, (JsonSerializerOptions?)null),
                x => JsonSerializer.Deserialize<List<DateOnly>>(x, (JsonSerializerOptions?)null) ?? new())
            .HasColumnType("nvarchar(max)")
            .HasColumnName("BlockedDatesJson")
            .Metadata.SetValueComparer(datelistComparer);
    }
}