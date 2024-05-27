using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace HW;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        IConfiguration config = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

        builder.Services.AddOcelot(config);
        builder.Services.AddSwaggerForOcelot(config);
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerForOcelotUI(opt =>
        {
          opt.PathToSwaggerGenerator = "/swagger/docs";
        }).UseOcelot().Wait();

        
        //app.UseSwaggerUI();
        

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
