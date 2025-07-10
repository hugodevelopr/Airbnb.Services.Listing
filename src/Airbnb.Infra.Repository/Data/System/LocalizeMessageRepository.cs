using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.SharedKernel.Repositories;

namespace Airbnb.Infra.Repository.Data.System;

public class LocalizeMessageRepository : BaseRepository, ILocalizeMessageRepository
{
    public async Task<LocalizeMessage> GetMessageAsync(string key, string language)
    {
        throw new NotImplementedException();
    }
}