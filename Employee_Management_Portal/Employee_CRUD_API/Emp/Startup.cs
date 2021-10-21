using Emp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Emp.Providers;

namespace Emp
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
            services.AddMvc().AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddLogging();
            services.AddDbContext<EmployeeTableContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConDb")));
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IDeptRepository, DeptRepository>();
            services.AddScoped< EmployeeProviderInterface,EmployeeProvider>();
            services.AddScoped<DepartmentProviderInterface, DepartmentProvider>();
            services.AddSwaggerGen();
           

            //            GlobalConfiguration.Configuration
            //.EnableSwagger(c => c.SingleApiVersion("Version", "Project Name"))
            //.EnableSwaggerUi();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .SetIsOriginAllowed(origin => true)
                               .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
