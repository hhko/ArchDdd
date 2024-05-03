using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection;

internal static class OpenApiRegistration
{
    //private const string WwwRootDirectoryName = "OpenApi";
    //private const string ArchiWorkshopPresentation = $"{nameof(ArchiWorkshop)}.{nameof(ArchiWorkshop.Adapters)}.{nameof(ArchiWorkshop.Adapters.Presentation)}";

    internal static IServiceCollection RegisterOpenApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, OpenApiOptionsSetup>();
        services.AddSwaggerGen();

        return services;
    }

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}

public class OpenApiOptionsSetup : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public OpenApiOptionsSetup(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "ArchDdd",
            Version = description.ApiVersion.ToString(),
            Description = "아키텍처 with 도메인 주도 설계",
            Contact = new OpenApiContact() { Name = "고형호", Email = "hyungho.ko@gmail.com" },
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}
