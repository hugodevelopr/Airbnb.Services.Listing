using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map;

public class ListingMap : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.ToTable("Listing", "Listing");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.HostId)
            .IsRequired();

       builder.Property(x => x.Bedrooms)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(x => x.Beds)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(x => x.Bathrooms)
            .HasDefaultValue(0)
            .IsRequired();
    }
}