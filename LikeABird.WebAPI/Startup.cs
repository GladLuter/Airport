
using LikeABird.ALL.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LikeABird.WebAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            InjectionResolver.ConfigurateInjections(services);

            services.AddControllers( c => c.EnableEndpointRouting = false);
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LikeABird.WebAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            //var mapperConfig = new MapperConfiguration(mc => {
            //    mc.AddProfile(new DAL_to_ALL());
            //});

            //var mapper = mapperConfig.CreateMapper();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LikeABird.WebAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            //app.UseCors(builder => {
            //    builder.AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials();
            //});
            ServicesAppender.AddServicesMVC(app);
            //app.UseMvc(routes => {
            //    routes.MapRoute("api", "api/users", new { controller = "AO_User", action = "Get" });
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=AO_User}/{action=Get}/{id?}");
            //});

            //app.UseEndpoints(endpoints => {
            //    endpoints.MapControllers();
            //});
        }
    }
}
