using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ArchDdd.Abstractions.Utilities;

public static class BuilderUtilities
{
    public static IHostApplicationBuilder AddJsonConfigurationFiles(this IHostApplicationBuilder builder)
    {
        var env = builder.Environment;

        Console.WriteLine($"------------------------->");
        Console.WriteLine($"{env.EnvironmentName}");
        string configurationsDirectory = Path.Combine(Path.GetDirectoryName(AssemblyReference.Assembly.Location)!, "Configurations");

        //builder.Configuration
        //    .AddJsonFile($"{configurationsDirectory}/Database.json", optional: false, reloadOnChange: true)
        //    .AddJsonFile($"{configurationsDirectory}/Database.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        var jsonFilesWithoutDotInName = Directory.GetFiles(configurationsDirectory, "*.json")
            .Where(file => Path.GetFileNameWithoutExtension(file).IndexOf('.') == -1);

        foreach (var jsonFile in jsonFilesWithoutDotInName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(jsonFile);
            string expectedFileName = $"{fileNameWithoutExtension}.{env.EnvironmentName}.json";

            if (!File.Exists(Path.Combine(configurationsDirectory, expectedFileName)))
            {
                throw new FileNotFoundException($"Cannot find {expectedFileName} file in {configurationsDirectory}");
            }

            builder.Configuration.AddJsonFile(jsonFile, optional: false, reloadOnChange: true);
        }

        return builder;
    }
}
