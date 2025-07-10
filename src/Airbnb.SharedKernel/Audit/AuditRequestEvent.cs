using Airbnb.SharedKernel.Events;

namespace Airbnb.SharedKernel.Audit;

public class AuditRequestEvent : IIntegrationEvent
{
    public string ServiceName { get; set; } = string.Empty;
    public string HttpMethod { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public Dictionary<string, string> Headers { get; set; } = new();
    public string? Body { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}