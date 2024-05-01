var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

// builder.Environment
builder.Services
    .RegisterAdaptersInfrastructureLayer()
    .RegisterAdaptersPersistenceLayer()
    .RegisterAdaptersPresentationLayer();

WebApplication webApplication = builder.Build();

webApplication.Run();