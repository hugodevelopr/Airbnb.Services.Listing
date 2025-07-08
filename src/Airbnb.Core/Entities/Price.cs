using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;


public class Price : BaseEntity
{
    public decimal BasePrice { get; private set; }                          //Price by night
    public string Currency { get; private set; } = string.Empty;            //ISO code 4217 (e.g. USD, BRL, EUR)
    public decimal? CleaningFee { get; private set; }
    public decimal? SecurityDeposit { get; private set; }                   
    public decimal? WeeklyDiscount { get; private set; }
    public decimal? MonthlyDiscount { get; private set; }
    public decimal? ExtraGuestFee { get; private set; }                    
    public Guid ListingId { get; private set; }

}