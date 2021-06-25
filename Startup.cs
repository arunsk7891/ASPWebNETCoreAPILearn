using ASPWebNETCoreAPI.DBContexts;
using ASPWebNETCoreAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace ASPWebNETCoreAPI
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

            services.AddControllers();
           
            //services.AddSingleton<WeatherForecast, WeatherForecast>();
           services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ProductContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ProductDB")));
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Details Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASPWebNETCoreAPI", Version = "v1" });
            });
        
        */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v2/swagger.json", "ASPWebNETCoreAPI v2"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            

            app.UseRouting();

           // app.UseAuthorization();
            

        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          

        }
    }
}
