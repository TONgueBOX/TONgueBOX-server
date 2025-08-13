using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Serilog;
using Tongue.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));
    
    // custom extensions
    builder.Services.AddDatabaseContexts(builder.Configuration);
    builder.Services.AddDependencyInjections();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Tongue Api {builder.Environment.EnvironmentName}"));
    }

    app.UseHttpsRedirection();

    // app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Lifetime.ApplicationStarted.Register(() =>
    {
        if (!app.Environment.IsDevelopment()) return;
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        var addresses = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()?.Addresses;

        if (addresses == null) return;
        foreach (var address in addresses)
        {
            logger.LogInformation("Swagger link: {SwaggerUrl}", $"{address}/swagger");
        }
    });


    app.Run();
}
