using Airbnb.Core.Entities;

namespace Airbnb.Core.Services;

public interface ILocalizeMessageService : IDisposable
{
    Task<LocalizeMessage> GetMessageAsync(string key, string language = "en-us");
}