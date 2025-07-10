using System.Text;
using Airbnb.Api.Infrastructure.Audit;
using Airbnb.SharedKernel;

namespace Airbnb.Api.Infrastructure.Middlewares;

public class AuditMiddleware(RequestDelegate next, AuditPublisherDelegate auditDelegate)
{
    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

        string? body = null;

        if (request is { ContentLength: > 0, Body.CanRead: true })
        {
            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
        }

        var message = new AuditRequestMessage
        {
            ServiceName = AirbnbSettings.ServiceName,
            HttpMethod = request.Method,
            Path = request.Path,
            Headers = headers,
            Body = body,
            Timestamp = DateTime.UtcNow
        };

        await auditDelegate(message);

        await next(context);
    }
}