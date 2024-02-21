using Customer.Api.Data;

namespace Customer.Api
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
          .AddInfrastructure();
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
