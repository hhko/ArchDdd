using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ArchDdd.Abstractions.Utilities;

public static class BuilderUtilities
{
    public static IHostApplicationBuilder AddConfigurations(this IHostApplicationBuilder builder)
    {
        const string configurationsDirectory = "Configurations";
        var env = builder.Environment;

        builder.Configuration
            .AddJsonFile($"{configurationsDirectory}/Database.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{configurationsDirectory}/database.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        return builder;
    }
}
