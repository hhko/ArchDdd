using ArchDdd.Adapters.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

//  OptionsRegistration
//      RegisterOptions
//          DatabaseOptionsSetup          설정 값 읽기
//              IConfigureOptions<DatabaseOptions>
//              services.ConfigureOptions<DatabaseOptionsSetup>();
//          DatabaseOptionsValidator      설정 값 유효성 검사
//              IValidateOptions<DatabaseOptions>
//              services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();
//          DatabaseOptions               설정 값

public static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>()
                .AddOptionsWithValidateOnStart<DatabaseOptions>();

        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

        return services;
    }
}