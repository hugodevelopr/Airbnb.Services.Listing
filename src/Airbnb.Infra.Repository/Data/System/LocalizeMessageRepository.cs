using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.SharedKernel.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Airbnb.Infra.Repository.Data.System;

public class LocalizeMessageRepository : BaseRepository, ILocalizeMessageRepository
{
    private readonly ILogger<LocalizeMessageRepository> _logger;

    /// <inheritdoc />
    public LocalizeMessageRepository(IConfiguration configuration, ILogger<LocalizeMessageRepository> logger)
        : base(configuration)
    {
        _logger = logger;
    }

    public async Task<LocalizeMessage> GetMessageAsync(string key, string language)
    {
        throw new NotImplementedException();
    }
}