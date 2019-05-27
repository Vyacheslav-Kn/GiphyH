using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using GiphyH.DAL.Database;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GiphyH.BLL.Services;
using GiphyH.BLL.Interfaces;
using GiphyH.DAL.GifMapper;
using GiphyH.DAL.UserMapper;
using GiphyH.DAL.GifHandlers;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.GifInterfaces;
using GiphyH.DAL.UserInterfaces;
using GiphyH.DAL.UserHandlers;
using GiphyH.BLL.MapperGifDTO;

namespace GiphyH
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            InjectServices(services);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.Use(async (ctx, next) =>
                {
                    await next();
                    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                    {
                        ctx.Request.Path = "/Home/Index";
                        await next();
                    }
                });

                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

        private void InjectServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient<IGifHandler, GifHandler>();
            services.AddTransient<IGifService, GifService>();
            services.AddTransient<IUserHandler, UserHandler>();
            services.AddSingleton<ICryptoService, CryptoService>();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommandsToGif());
                mc.AddProfile(new CommandsToUser());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
