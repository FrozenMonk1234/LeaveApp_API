using LeaveApp_API.Models;
using LeaveApp_API.Repository.Leave;
using LeaveApp_API.Repository.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeaveApp_API
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
            services.AddDbContext<LeaveDbContext>(o => o.UseSqlServer(Configuration["connectionstrings:DBConnection"]));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LeaveAPP_API", Version = "v3" });

            });
            services.AddCors(o => o.AddPolicy("LeaveApp-GateKeeper-Policy",
                 b =>
                 {
                     b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                 }));

            //services.AddMvc(o => o.EnableEndpointRouting = false)
            //    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
            //    .AddNewtonsoftJson
                

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            // services.AddRazorPages();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(s => {
                    s.SwaggerEndpoint("v1/swagger.json", "Leave App API");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            //app.UseStaticFiles();
            //app.UseMvc();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
