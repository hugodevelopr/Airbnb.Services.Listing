using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;

public class Host : BaseEntity
{
    public Guid UserId { get; set; }
}