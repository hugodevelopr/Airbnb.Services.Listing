using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map;

public class LocationMap : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Location", "Listing");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(i => i.Country)
                .HasColumnName("Country")
                .HasMaxLength(100)
                .IsRequired();

            address.Property(i => i.State)
                .HasColumnName("State")
                .HasMaxLength(100)
                .IsRequired();

            address.Property(i => i.City)
                .HasColumnName("City")
                .HasMaxLength(100)
                .IsRequired();

            address.Property(i => i.Street)
                .HasColumnName("Street")
                .HasMaxLength(200)
                .IsRequired();

            address.Property(i => i.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(20)
                .IsRequired();
        });

        builder.Property(x => x.Latitude)
            .IsRequired();

        builder.Property(x => x.Longitude)
            .IsRequired();

        builder.HasOne<Listing>()
            .WithOne()
            .HasForeignKey<Location>(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Id);
    }
}