using ArchDdd.Abstractions.Utilities;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder
    .AddConfigurations();

builder.Services
    .RegisterAdaptersInfrastructureLayer(builder.Logging)
    .RegisterAdaptersPersistenceLayer()
    .RegisterAdaptersPresentationLayer()
    .RegisterApplicationLayer();

WebApplication app = builder.Build();

// UseHttpsRedirection()
// UseAuthorization()
app.UseAdaptersPresentationLayer();

app.MapControllers();
app.Run();