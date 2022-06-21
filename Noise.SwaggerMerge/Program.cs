using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Noise.SwaggerMerge.Merge;
using Noise.SwaggerMerge.Merge.Configuration;
using Noise.SwaggerMerge.Merge.Configuration.Input;
using Noise.SwaggerMerge.Merge.Configuration.Output;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SwaggerInputConfiguration>(builder.Configuration.GetSection("ServiceSwaggerEndpoint"));
builder.Services.Configure<SwaggerOutputConfiguration>(builder.Configuration.GetSection("SwaggerConfig"));
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocumentTitle = "VTuberMusic Noise Swagger Center";
    c.SwaggerEndpoint("/noise/v1/swagger.json", "Noise Api");
});

app.MapGet("/noise/v1/swagger.json", async () =>
{
    SwaggerInputConfiguration[] inputs = builder.Configuration.GetSection("ServiceSwaggerEndpoint").Get<SwaggerInputConfiguration[]>();
    SwaggerOutputConfiguration outputs = builder.Configuration.GetSection("SwaggerConfig").Get<SwaggerOutputConfiguration>();

    SwaggerMergeConfiguration config = new SwaggerMergeConfiguration();
    config.Inputs = inputs;
    config.Output = outputs;

    return await SwaggerMerger.MergeAsync(config);
});



app.Run();
