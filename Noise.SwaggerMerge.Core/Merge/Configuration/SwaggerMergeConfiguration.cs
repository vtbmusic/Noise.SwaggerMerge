namespace Noise.SwaggerMerge.Merge.Configuration;

using Noise.SwaggerMerge.Merge.Configuration.Input;
using Noise.SwaggerMerge.Merge.Configuration.Output;

/// <summary>
/// Defines the configuration for merging Swagger documents.
/// </summary>
public class SwaggerMergeConfiguration
{
    /// <summary>
    /// Gets or sets the inputs for merging.
    /// </summary>
    public IEnumerable<SwaggerInputConfiguration> Inputs { get; set; } = new List<SwaggerInputConfiguration>();

    /// <summary>
    /// Gets or sets the output merged Swagger document.
    /// </summary>
    public SwaggerOutputConfiguration Output { get; set; } = new();
}