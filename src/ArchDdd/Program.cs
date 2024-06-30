var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services
    .RegisterAdaptersInfrastructureLayer(builder.Logging)
    .RegisterAdaptersPersistenceLayer(builder.Environment)
    .RegisterAdaptersPresentationLayer()
    .RegisterApplicationLayer();

WebApplication app = builder.Build();

// UseHttpsRedirection()
// UseAuthorization()
app.UseAdaptersPresentationLayer();

app.MapControllers();
app.Run();