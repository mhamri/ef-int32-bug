using System;
using System.Reflection;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Research.Dotnet5AndOdata.Db;
using Research.Dotnet5AndOdata.Entities;
using Research.Dotnet5AndOdata.Models;

namespace Research.Dotnet5AndOdata
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            

            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                     x => x.CommandTimeout((int) TimeSpan.FromMinutes(3).TotalSeconds));
            });

            services.AddScoped<DbContext, MyContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddControllers();
            services.AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5)
                                        
                                        .AddModel("odata", GetEdmModel())
                                        
                              //.ConfigureRoute(route => route.EnableQualifiedOperationCall = false) // use this to configure the built route template
                             );

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint == null)
                {
                    return next(context);
                }

                return next(context);
            });

            app.UseAuthorization();

            //UseMvcSettings(app, env);

            app.UseEndpoints(endpoints => {
                
                endpoints.MapGet("/$odata", ODataRouteHandler.HandleOData);
                endpoints.MapControllers();
            });
        }

        public static IEdmModel GetEdmModel() {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<BookModel>("Books");
            builder.EntitySet<PersonModel>("People");
            builder.EntitySet<StoreModel>("StoresProjected");
            builder.EntitySet<Store>("StoresSimple");
            builder.EntitySet<BookStoreModel>("BookStores").EntityType.HasKey(vote => new { vote.BookId, vote.StoreId});

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }

        public static void UseMvcSettings(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }

    public class MyRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            Console.WriteLine("HOOOOOOOOOOOOOOOOOOOOOOOOO");
            config.Default.PreserveReference(true);
        }
    }
}

public class MyRegister : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        Console.WriteLine("kkkkkkkkkkkkkkkkkkkkkkkk");

        config.Default.PreserveReference(true);

        //config.AdaptTo("[name]Dto")
        //    .ForType<StoreModel>()
        //    //.ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "Research.Dotnet5AndOdata")
        //    ;

        //config.GenerateMapper("[name]Mapper")
        //    .ForType<StoreModel>();

    }
}
