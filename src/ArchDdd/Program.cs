var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services
    .RegisterAdaptersInfrastructureLayer()
    .RegisterAdaptersPersistenceLayer()
    .RegisterAdaptersPresentationLayer()
    .RegisterApplicationLayer();

WebApplication app = builder.Build();

// UseHttpsRedirection()
// UseAuthorization()
app.UseAdaptersPresentationLayer();

app.MapControllers();
app.Run();

public sealed partial class Program : IDisposable
{
    public Program()
    {
        
    }

    public void Dispose()
    {
    }
}