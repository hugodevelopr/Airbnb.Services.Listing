using Airbnb.Api.Infrastructure.Audit;

namespace Airbnb.SharedKernel.Audit;

public delegate Task AuditPublisherDelegate(AuditRequestMessage message);