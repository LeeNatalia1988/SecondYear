using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserWorker.Mapping;
using UserWorker.Repository;
using UserWorker.Abstractions;
using UserWorker.AuthorizationModels;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using Autofac.Extensions.DependencyInjection;
using Autofac;




namespace MyChat
{
    
    public class Program
    {
        static RSA GetPublicKey()
        {
            var f = File.ReadAllText("rsa/public_key.pem");

            var rsa = RSA.Create();
            rsa.ImportFromPem(f);
            return rsa;
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddMemoryCache(x => x.TrackStatistics = true);
            builder.Services.AddEndpointsApiExplorer();

            

            //builder.Services.AddScoped<IUserAuthenticationService, AuthenticationMock>();

            
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Пожалуйста, введите свой token",
                    Name = "Авторизация",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "Token",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            //builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.RegisterType<UserRepository>().As<IUserRepository>();
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtConfiguration:Issuer"],
                    ValidAudience = builder.Configuration["JwtConfiguration:Audience"],
                    IssuerSigningKey = new RsaSecurityKey(GetPublicKey())
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfiguration:Key"]))
                };
            });

          

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}

