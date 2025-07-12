using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class PriceHistory : BaseEntity
{
    private readonly LinkedList<decimal> _priceVersions = new();
    public IReadOnlyCollection<decimal> Prices => _priceVersions.ToList().AsReadOnly();
    public decimal CurrentPrice => _priceVersions.Last!.Value;

    private PriceHistory()
    {
    }

    public PriceHistory(decimal initialPrice)
    {
        _priceVersions.AddLast(initialPrice);
    }

    public void AddPrice(decimal newPrice)
    {
        if (_priceVersions.Last?.Value != newPrice)
            _priceVersions.AddLast(newPrice);
    }

    public bool RollbackPrice()
    {
        if (_priceVersions.Count <= 1)
            return false;

        _priceVersions.RemoveLast();
        return true;
    }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}