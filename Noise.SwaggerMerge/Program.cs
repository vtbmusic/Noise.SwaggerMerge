using Microsoft.Extensions.Configuration;
using Noise.SwaggerMerge.Merge;
using Noise.SwaggerMerge.Merge.Configuration;
using Noise.SwaggerMerge.Merge.Configuration.Input;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SwaggerInputConfiguration>(builder.Configuration.GetSection("SwaggerConfig"));
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/test", async () =>
{
    SwaggerInputConfiguration[] inputs = builder.Configuration.GetSection("SwaggerConfig").Get<SwaggerInputConfiguration[]>();
    SwaggerMergeConfiguration config = new SwaggerMergeConfiguration();
    config.Inputs = inputs;

    return await SwaggerMerger.MergeAsync(config);
});

app.Run();
