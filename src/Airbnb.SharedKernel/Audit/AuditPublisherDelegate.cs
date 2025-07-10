namespace Airbnb.SharedKernel.Audit;

public delegate Task AuditPublisherDelegate(AuditRequestEvent message);