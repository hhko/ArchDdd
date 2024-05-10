namespace Microsoft.Extensions.DependencyInjection;

internal static class ControllerRegistration
{
    internal static IServiceCollection RegisterControllers(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddApplicationPart(ArchDdd.Adapters.Presentation.AssemblyReference.Assembly);
            //.ConfigureApiBehaviorOptions(options =>
            //    options.InvalidModelStateResponseFactory = ApiBehaviorOptions.InvalidModelStateResponse)
            //.AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new RequiredPropertiesCamelCaseContractResolver();
            //    options.SerializerSettings.Formatting = Indented;
            //    options.SerializerSettings.Converters.Add(new StringEnumConverter());
            //    options.SerializerSettings.ReferenceLoopHandling = Ignore;
            //});

        return services;
    }
}
