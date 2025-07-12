using Microsoft.AspNetCore.Mvc.Filters;

namespace Airbnb.Api.Infrastructure.Filters;

public class UserContextInjectionFilter(IHttpContextAccessor httpContextAccessor) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("sub")?.Value ?? string.Empty);

            foreach (var argument in context.ActionArguments.Values)
            {
                var userIdProperty = argument?.GetType().GetProperty("UserId");

                if(userIdProperty != null && userIdProperty.CanWrite)
                {
                    userIdProperty.SetValue(argument, userId);
                }
            }

        }

        await next();
    }
}