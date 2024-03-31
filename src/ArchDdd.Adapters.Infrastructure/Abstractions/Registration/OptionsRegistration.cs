using ArchDdd.Adapters.Infrastructure.Options;
using FluentValidation;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

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
        // AddOptionsWithValidateOnStart 메서드는 생성자 주입되는 클래스가 존재해야 한다.
        //
        // System.MissingMethodException: 
        //    'Cannot dynamically create an instance of type 'ArchDdd.Adapters.Infrastructure.Options.DatabaseOptionsSetup'. 
        //    Reason: No parameterless constructor defined.'

        //// interface IConfigureOptions<in TOptions>
        ////      void Configure(TOptions options);
        //services.ConfigureOptions<DatabaseOptionsSetup>();



        // Case2
        services.AddOptions<DatabaseOptions>()
            .BindConfiguration(DatabaseOptions.ConnectionStrings)
            .BindConfiguration(DatabaseOptions.DatabaseCountOptions)
            .ValidateFluentValidation();


        //services.AddWithValidation<DatabaseOptions, DatabaseOptionsValidator2>("ConnectionStrings");


        //.BindConfiguration("")
        //.ValidateFluentValidation();
        //services.AddOptions<DatabaseOptionsSetup>();

        ////// interface IValidateOptions<TOptions>
        //////      ValidateOptionsResult Validate(string? name, TOptions options);
        ////services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

        // Production vs. Development 구분 읽기
        // 키 캡슐화
        // 복수 키일 꼉우

        // AddOptions IConfigureOptions

        //services.AddOptions<DatabaseOptions>();
        //services.AddOptions<SlackApiSettings>()
        //    .BindConfiguration("SlackApi")
        //    .ValidateFluentValidation() // <- Enable validation
        //    .ValidateOnStart(); // <- Validate on app start

        return services;
    }
}

public class SlackApiSettings
{
    public SlackApiSettings()
    {

    }

    public string? WebhookUrl { get; set; }
    public string? DisplayName { get; set; }
    public bool ShouldNotify { get; set; }
}

public class SlackApiSettingsValidator : AbstractValidator<SlackApiSettings>
{
    public SlackApiSettingsValidator()
    {
        RuleFor(x => x.DisplayName).NotEmpty();
        RuleFor(x => x.WebhookUrl).NotEmpty()
                                  .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                                  .When(x => !string.IsNullOrEmpty(x.WebhookUrl));
        // .MustAsync((_, _) => Task.FromResult(true)) 👈 can't use async validators
    }
}

public static class FluentValidationOptionsExtensions
{
    public static OptionsBuilder<TOptions> AddWithValidation<TOptions, TValidator>(
        this IServiceCollection services,
        string configurationSection)
    where TOptions : class
    where TValidator : class, IValidator<TOptions>
    {
        services.AddScoped<IValidator<TOptions>, TValidator>();

        return services.AddOptions<TOptions>()
            .BindConfiguration(configurationSection)
            .ValidateFluentValidation()
            .ValidateOnStart();
    }
}

public static class OptionsBuilderFluentValidationExtensions
{
    /// <summary>
    /// Register this options instance for validation using FluentValidation
    /// Note that you _can't_ use async validators, or you will get an exception at runtime.
    /// </summary>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <param name="optionsBuilder">The options builder to add the services to.</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider));
        

        return optionsBuilder;
    }
}

public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string? _name;

    public FluentValidationOptions(string? name, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _name = name;
    }

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        // Null name is used to configure all named options.
        if (_name != null && _name != name)
        {
            // Ignored if not validating this instance.
            return ValidateOptionsResult.Skip;
        }

        // Ensure options are provided to validate against
        ArgumentNullException.ThrowIfNull(options);

        // Validators are registered as scoped, so need to create a scope,
        // as we will be called from the root scope
        using IServiceScope scope = _serviceProvider.CreateScope();
        IValidator<TOptions> validator = scope.ServiceProvider.GetRequiredService<IValidator<TOptions>>();
        FluentValidation.Results.ValidationResult results = validator.Validate(options);
        if (results.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        string typeName = options.GetType().Name;
        var errors = new List<string>();
        foreach (var result in results.Errors)
        {
            errors.Add($"Fluent validation failed for '{typeName}.{result.PropertyName}' with the error: '{result.ErrorMessage}'.");
        }

        return ValidateOptionsResult.Fail(errors);
    }
}