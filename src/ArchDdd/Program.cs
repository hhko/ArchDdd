using ArchDdd.Abstractions.Utilities;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

// .json 파일
builder
    .AddJsonConfigurationFiles();

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