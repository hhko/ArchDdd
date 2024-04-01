using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ArchDdd.Adapters.Infrastructure.Options.Utilities;

internal static class OptionsBuilderFluentValidationUtilities
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider));


        return optionsBuilder;
    }
}
