using Identity.Api.Database;
using Identity.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      builder.Services.AddAuthorization();

      builder.Services.AddAuthentication()
        .AddBearerToken(IdentityConstants.BearerScheme);

      builder.Services.AddIdentityCore<IdentityUser>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddApiEndpoints();

      builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      if (args.Contains("apply-migrations"))
      {
        app.ApplyMigrations();
      }

      app.UseHttpsRedirection();
      app.MapIdentityApi<IdentityUser>();

      app.MapControllers();

      app.Run();
    }
  }
}
