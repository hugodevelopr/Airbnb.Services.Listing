using Airbnb.Api.Infrastructure.Middlewares;
using Airbnb.Infra.DependencyInjection;
using Figgle.Fonts;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(FiggleFonts.Doom.Render("Airbnb.Service.Listing"));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAirbnbDependencies(builder.Configuration);

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Airbnb Listing");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(configure: endpoints => { _ = endpoints.MapControllers(); });

app.UseMiddleware<AuditMiddleware>();

app.Run();
