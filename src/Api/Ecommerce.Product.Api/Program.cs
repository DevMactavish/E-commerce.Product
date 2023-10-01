using Ecommerce.Product.Api.Extension;
using Ecommerce.Product.Api.Middlewares;
using Ecommerce.Product.Application;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.UseElasticWithSeriLog(builder.Configuration);


builder.Services
    .AddApiVersioning()
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddDatabase(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
    .AddControllers();
builder.Services.AddTransient<GlobalErrorHandlingMiddleware>();

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI()
    .UseAuthorization()
    .UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();

app.MapControllers();
app.Run();