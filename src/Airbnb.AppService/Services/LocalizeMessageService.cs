using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.Core.Services;
using Airbnb.SharedKernel.Common;
using Airbnb.SharedKernel.Services;

namespace Airbnb.AppService.Services;

public class LocalizeMessageService(ILocalizeMessageRepository localizeMessageRepository) : BaseService, ILocalizeMessageService
{
    public async Task<LocalizeMessage> GetMessageAsync(string key, string language = "en-us")
    {
        key.NotNullOrEmpty(nameof(key));

        return await localizeMessageRepository.GetMessageAsync(key, language);
    }
}