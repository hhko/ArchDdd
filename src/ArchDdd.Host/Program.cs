//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

////ArchDdd.Domain.ClassDomain ssasfssc = nArchDdd.Domain.ClassDomain();
////c.DoSomething();sfsfuasdfyui0-ss


//using ArchDdd.Host.Abstractions.Registration;

using ArchDdd.Adapters.Infrastructure.Options;
using FluentValidation;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services.RegisterAdapterInfrastructureLayer()
                .RegisterAdapterPersistenceLayer(builder.Environment);

//builder.Services.AddWithValidation<SlackApiSettings, SlackApiSettingsValidator>("SlackApi");

//builder.Services.AddScoped<IValidator<SlackApiSettings>, SlackApiSettingsValidator>();

//builder.Services.AddOptions<SlackApiSettings>()
//    .BindConfiguration("SlackApi")
//    .ValidateFluentValidation() // <- Enable validation
//    .ValidateOnStart(); // <- Validate on app start

//// Optional: Explicitly register the settings object by delegating to the IOptions object
//builder.Services.AddSingleton(resolver =>
//        resolver.GetRequiredService<IOptions<SlackApiSettings>>().Value);

WebApplication webApplication = builder.Build();

//var x = builder.Services.GetOptions<DatabaseOptions>();

//var serviceProvider = builder.Services.BuildServiceProvider();
//var x = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

//webApplication
//    .UseHttpsRedirection()
//    .UseApplicationLayer()
//    .UsePresentationLayer(builder.Environment)
//    .UsePersistenceLayer();

//webApplication.MapControllers();

//Run the application
webApplication.Run();





