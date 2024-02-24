using Customer.Api.Data;
using Customer.Api.Messaging.Send;
using Customer.Api.Service;

namespace Customer.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      {
        builder.Services
          .AddApiDependencies(builder.Configuration)
          .AddPersistence(builder.Configuration)
          .AddMessagingDependencies()
          .AddServiceDependencies();
      }

      var app = builder.Build();
      {
        if (app.Environment.IsDevelopment())
        {
          app.UseDeveloperExceptionPage();
        }
        else
        {
          app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
          c.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        app.Run();
      }
    }
  }
}
