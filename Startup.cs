using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using rflap_metrics.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace rflap_metrics
{
    public class Startup
    {

            public readonly string RflapOrigins = "Rflap Origins";

            public readonly string connectionString = "Server=tcp:rflap-metrics.database.windows.net,1433;Initial Catalog=submissions_and_tests_2020-05-16T02-20Z;Persist Security Info=False;User ID=heldeo;Password=1Tegarde;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExportContext>(options => options.UseSqlServer(connectionString, options => options.EnableRetryOnFailure()));
            services.AddDbContext<TestContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<TestResultContext>(options => options.UseSqlServer(connectionString));
            services.AddCors(options =>
           {
               options.AddDefaultPolicy(
                          builder =>
                         {
                             builder.WithOrigins("https://rflap.azurewebsites.net",
                                                            "https://rflap.acmuic.app").AllowAnyMethod().AllowAnyHeader();


                         });


           });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            // UseCors must be after routing but prior to authorization
            app.UseCors();

            app.UseAuthorization();

        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
