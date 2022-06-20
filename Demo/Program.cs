using Demo.Database;
using Microsoft.EntityFrameworkCore;

StartApplication();

void StartApplication()
{
    var builder = WebApplication.CreateBuilder(args);

    ConfigureServices(builder.Services);

    var app = builder.Build();

    ConfigurePipeline(app);

    UpdateDb(app);

    app.Run();
}

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddDbContext<DemoContext>();

    // Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void ConfigurePipeline(IApplicationBuilder app)
{
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Middleware
    app.Use(async (context, next) =>
    {
        Console.WriteLine($"{context.Request.Method} {context.Request.Path}");
        Console.WriteLine($"Endpoint: {context.GetEndpoint()?.DisplayName}");
        await next();
    });

    // Maps incoming request to appropriate endpoint
    app.UseRouting();

    // Middleware
    app.Use(async (context, next) =>
    {
        Console.WriteLine($"Endpoint: {context.GetEndpoint()?.DisplayName}");
        await next();
    });

    // Executes mathced endpoint
    // If request mathced with an endpoint by UseRouting,this is a terminal middleware, means that request will not continue with other middlewares in pipline
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    // Next middleware in pipeline 
    app.Use(async (context, next) =>
    {
        Console.WriteLine($"Last middlewere works only if UseEndpoints doesn't terminate pipeline");
        await next();
    });
}

void UpdateDb(IApplicationBuilder app)
{
    using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

    using DemoContext? context = serviceScope.ServiceProvider.GetService<DemoContext>();

    context?.Database.Migrate();
}