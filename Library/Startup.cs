using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.MapperProfiles;
using Library.BLL.Servises;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Library
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
             Mapper.Initialize(cfg =>
             {
                 cfg.AddProfile(new BookProfile());
                 cfg.AddProfile(new MagazineProfile());
                 cfg.AddProfile(new BrochureProfile());
                 cfg.AddProfile(new PublicHouseProfile());
                 cfg.AddProfile(new ViewModelToEntityMappingProfile());
              });

            services.AddMvc();

            services.AddTransient<PublicationHouseService>();
            services.AddTransient<BrochureService>();
            services.AddTransient<MagazineService>();
            services.AddTransient<BookService>();

            



        }


    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             if (env.IsDevelopment())
             {
                  app.UseDeveloperExceptionPage();
             }
             else
             {
                  app.UseExceptionHandler("/Home/Error");
             }

      //app.UseMvc(routes =>
      //{
      //    routes.MapRoute(
      //        name: "default",
      //        template: "{controller}/{action=Index}/{id?}");
      //});

      //app.Use(async (context, next) =>
      //{
      //    await next();
      //    if (context.Response.StatusCode == 404 &&
      //         !Path.HasExtension(context.Request.Path.Value) &&
      //         !context.Request.Path.Value.StartsWith("/api/"))
      //    {
      //       context.Request.Path = "/index.html";
      //        await next();
      //    }
      //});

      // app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
           
        }
    }
}
