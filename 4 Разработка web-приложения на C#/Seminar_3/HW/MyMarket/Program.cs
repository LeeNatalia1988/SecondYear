using Autofac;
using Autofac.Extensions.DependencyInjection;

using MyMarket.Abstractions;
using MyMarket.GraphQLServices.Mutation;
using MyMarket.GraphQLServices.Query;
using MyMarket.Mapping;
using MyMarket.Repository;
using Microsoft.Extensions.FileProviders;



namespace MyMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMemoryCache(x => x.TrackStatistics = true);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.RegisterType<ProductRepository>().As<IProductRepository>();
            });

            builder.Services.AddSingleton<IProductRepository, ProductRepository>().AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

            builder.Services.AddSingleton<IProductGroupRepository, ProductGroupRepository>();

            builder.Services.AddSingleton<IStorageRepository, StorageRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var staticOrderPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "OrderToCSV");
            Directory.CreateDirectory(staticOrderPath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticOrderPath),
                RequestPath = "/OrderToCSV"
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}
