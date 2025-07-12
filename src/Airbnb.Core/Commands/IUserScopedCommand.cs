namespace Airbnb.Core.Commands;

public interface IUserScopedCommand
{
    public Guid UserId { get; set; }
}