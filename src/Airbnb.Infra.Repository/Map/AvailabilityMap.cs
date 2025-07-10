using System.Text.Json;
using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
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

        builder.HasOne<Listing>()
            .WithOne()
            .HasForeignKey<Availability>(x => x.ListingId)
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

        builder.Property(x => x.BlockedDates)
            .HasConversion(
                x => JsonSerializer.Serialize(x, (JsonSerializerOptions?)null),
                x => JsonSerializer.Deserialize<List<DateOnly>>(x, (JsonSerializerOptions?)null) ?? new())
            .HasColumnType("nvarchar(max)")
            .HasColumnName("BlockedDatesJson");
    }
}