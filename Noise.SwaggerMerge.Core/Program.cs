namespace SwaggerMerge;

using Noise.SwaggerMerge.Merge;
using Noise.SwaggerMerge.Merge.Configuration;
using Noise.SwaggerMerge.Merge.Exceptions;
using Noise.SwaggerMerge.Serialization;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            if (args is not { Length: 1 })
            {
                throw new SwaggerMergeException("Please provide the Swagger merge configuration file.");
            }

            var configFile = args[0];

            var config = await GetSwaggerMergeConfigurationAsync(configFile);
            SwaggerMerger.ValidateConfiguration(config);
            await SwaggerMerger.MergeAsync(config);
        }
        catch (SwaggerMergeException sme)
        {
            Console.WriteLine(sme.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while merging Swagger documents. Detail: {e}");
        }
    }

    private static async Task<SwaggerMergeConfiguration> GetSwaggerMergeConfigurationAsync(string configFilePath)
    {
        SwaggerMergeConfiguration? config;

        try
        {
            config = await JsonFile.LoadFileAsync<SwaggerMergeConfiguration>(configFilePath);
            Directory.SetCurrentDirectory(Path.GetDirectoryName(configFilePath));
        }
        catch (Exception ex)
        {
            throw new SwaggerMergeException("The provided Swagger merge configuration file is not valid.", ex);
        }

        return config;
    }
}