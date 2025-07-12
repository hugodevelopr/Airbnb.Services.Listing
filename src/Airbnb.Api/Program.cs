using Airbnb.Api.Infrastructure;
using Airbnb.Api.Infrastructure.Middlewares;
using Airbnb.SharedKernel;
using Figgle.Fonts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(FiggleFonts.Doom.Render("Airbnb.Service.Listing"));

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddAirbnb(builder.Configuration);

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

ServiceLocator.SetLocatorProvider(app.Services);

app.Run();
