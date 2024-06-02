using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Security.Cryptography;

namespace MyChat.Chat
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

            builder.Services.AddOcelot(config);
            builder.Services.AddSwaggerForOcelot(config);



            var app = builder.Build();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            }).UseOcelot().Wait();


            //app.UseSwaggerUI();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
