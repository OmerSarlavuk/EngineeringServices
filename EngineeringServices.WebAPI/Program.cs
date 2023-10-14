using EngineeringServices.Business;
using EngineeringServices.WebAPI;
using EngineeringServices.WebAPI.Middlewares;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(@"C:\Logs\engineeringServicesLogsDetails.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApiServices(builder.Configuration);
        builder.Services.AddBusinessServices();
        builder.Services.AddCors(o => o.AddPolicy("Policy", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Middleware'leri düzgün sýralamaya dikkat edin.
        app.UseCustomException();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseRouting();
        app.UseHttpLogging();
        app.UseAuthorization();
        app.UseCors("Policy");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.Run();  
    }
}
