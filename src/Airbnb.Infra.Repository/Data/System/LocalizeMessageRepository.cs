using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.SharedKernel.Repositories;
using Microsoft.Extensions.Configuration;

namespace Airbnb.Infra.Repository.Data.System;

public class LocalizeMessageRepository : BaseRepository, ILocalizeMessageRepository
{
    /// <inheritdoc />
    public LocalizeMessageRepository(IConfiguration configuration)
        : base(configuration)
    {
    }

    public async Task<LocalizeMessage> GetMessageAsync(string key, string language)
    {
        throw new NotImplementedException();
    }
}