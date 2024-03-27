//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

////ArchDdd.Domain.ClassDomain ssasfssc = nArchDdd.Domain.ClassDomain();
////c.DoSomething();sfsfuasdfyui0-ss


//using ArchDdd.Host.Abstractions.Registration;

using Microsoft.Extensions.Options;

///
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services.RegisterHostOptions();

WebApplication webApplication = builder.Build();

//var x = builder.Services.GetOptions<DatabaseOptions>();

var serviceProvider = builder.Services.BuildServiceProvider();
var x = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

//webApplication
//    .UseHttpsRedirection()
//    .UseApplicationLayer()
//    .UsePresentationLayer(builder.Environment)
//    .UsePersistenceLayer();

//webApplication.MapControllers();

//Run the application
webApplication.Run();