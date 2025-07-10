using Airbnb.Core.Entities;

namespace Airbnb.Core.Repositories;

public interface ILocalizeMessageRepository
{
    Task<LocalizeMessage> GetMessageAsync(string key, string language);
}