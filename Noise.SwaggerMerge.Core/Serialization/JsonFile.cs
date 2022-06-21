namespace Noise.SwaggerMerge.Serialization;

using Newtonsoft.Json;

internal static class JsonFile
{
    internal static readonly JsonSerializerSettings Settings = new()
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore,
    };

    public static async Task<T> LoadFileAsync<T>(string filePath)
        where T : class
    {
        var content = await File.ReadAllTextAsync(filePath);
        var deserializedContent = JsonConvert.DeserializeObject<T>(content, Settings);
        if (deserializedContent == null)
        {
            throw new InvalidOperationException(
                $"File '{filePath}' could not be loaded correctly as it is not in the correct format.");
        }

        return deserializedContent;
    }
    public static async Task<T> LoadRemoteFileAsync<T>(string httpPath)
        where T : class
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.GetAsync(httpPath).Result.Content.ReadAsStringAsync().Result;
            var deserializedContent = JsonConvert.DeserializeObject<T>(response, Settings);
            if (deserializedContent == null)
            {
                throw new InvalidOperationException(
                    $"HttpFile '{httpPath}' could not be loaded correctly as it is not in the correct format.");
            }

            return deserializedContent;
        }

    }

    public static async Task SaveFileAsync<T>(string filePath, T data)
        where T : class
    {
        var content = JsonConvert.SerializeObject(data, Settings);
        await File.WriteAllTextAsync(filePath, content);
    }

    public static string OutJsonAsync<T>(T data)
    where T : class
    {
        return JsonConvert.SerializeObject(data, Settings);
    }
}