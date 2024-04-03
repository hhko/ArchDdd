var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services.RegisterAdapterInfrastructureLayer()
                .RegisterAdapterPersistenceLayer(builder.Environment);

WebApplication webApplication = builder.Build();

webApplication.Run();