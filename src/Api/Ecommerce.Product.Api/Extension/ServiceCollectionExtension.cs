using Ecommerce.Product.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Ecommerce.Product.Api.Extension;

public static class ServiceCollectionExtension
{
    public static WebApplicationBuilder UseElasticWithSeriLog(this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        var logConfig = configuration.GetSection("ElasticConfiguration").Value;

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(logConfig))
            {
                MinimumLogEventLevel = LogEventLevel.Information,
                AutoRegisterTemplate = true,
                IndexFormat = configuration.GetSection("ElasticSearchIndexName").Value + "-{0:yyyy.MM}"
            }).Destructure.AsScalar<byte[]>().CreateLogger();
        builder.Host.UseSerilog(Log.Logger);
        return builder;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductCommandDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("CommandConnectionString")));
        services.AddDbContext<ProductQueryDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("QueryConnectionString")));
        var context = services.BuildServiceProvider().GetRequiredService<ProductCommandDbContext>();
        context.Database.EnsureCreated();
        return services;
    }
}