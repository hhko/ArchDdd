using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Options.Utilities;

namespace Microsoft.Extensions.DependencyInjection;

//  OptionsRegistration
//      RegisterOptions
//          DatabaseOptionsSetup          설정 값 읽기
//            services.ConfigureOptions<DatabaseOptionsSetup>();
//          DatabaseOptionsValidator      설정 값 유효성 검사
//            services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();
//          DatabaseOptions               설정 값

internal static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.AddOptions<DatabaseOptions>()
            .BindConfiguration(DatabaseOptions.DatabaseConfig)
            .ValidateFluentValidation();

        return services;
    }
}

//public static class FluentValidationOptionsExtensions
//{
//    public static OptionsBuilder<TOptions> AddWithValidation<TOptions, TValidator>(
//        this IServiceCollection services,
//        string configurationSection)
//    where TOptions : class
//    where TValidator : class, IValidator<TOptions>
//    {
//        services.AddScoped<IValidator<TOptions>, TValidator>();

//        return services.AddOptions<TOptions>()
//            .BindConfiguration(configurationSection)
//            .ValidateFluentValidation()
//            .ValidateOnStart();
//    }
//}


