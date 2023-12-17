using DropoutCoder.SmartRental.Diagnostics;
using DropoutCoder.SmartRental.Infrastructure.Extensions;
using DropoutCoder.SmartRental.Operations.Extensions;
using DropoutCoder.SmartRental.Services;

namespace DropoutCoder.SmartRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDatabase("SmartRental");

            builder.Services.AddOperations();

            builder.Services.AddHostedService<InitializeDatabaseHostingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMiddleware<ApiExceptionHandlerMiddleware>();

            app.MapControllers();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}