using Order.Api.Data;
using Order.Api.Service;

namespace Order.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      {
        builder.Services
          .AddApiDependencies()
          .AddPersistence()
          .AddServiceDependencies();
      }

      var app = builder.Build();
      {
        app.UseHttpsRedirection();
        app.UseExceptionHandler();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
          c.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        app.Run();
      }
    }
  }
}
