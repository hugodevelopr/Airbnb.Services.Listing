using Airbnb.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infra.Repository.Map;

public class PriceMap : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.ToTable("Price", "Listing");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ListingId)
            .IsRequired();

        builder.Property(x => x.BasePrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(x => x.CleaningFee)
            .HasPrecision(18, 2);

        builder.Property(x => x.SecurityDeposit)
            .HasPrecision(18, 2);

        builder.Property(x => x.WeeklyDiscount)
            .HasPrecision(5, 2);

        builder.Property(x => x.MonthlyDiscount)
            .HasPrecision(5, 2);

        builder.Property(x => x.ExtraGuestFee)
            .HasPrecision(18, 2);

        builder.HasOne<Listing>()
            .WithOne()
            .HasForeignKey<Price>(x => x.ListingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}