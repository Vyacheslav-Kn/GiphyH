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
using GiphyH.BLL.MapperUserDTO;
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
            services.AddScoped<DAL.GifInterfaces.ICommonHandler, DAL.GifHandlers.CommonHandler>();
            services.AddScoped<IGifService, GifService>();
            services.AddScoped<DAL.UserInterfaces.ICommonHandler, DAL.UserHandlers.CommonHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ICryptoService, CryptoService>();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            IMapper mapper = ConfigureMapper();
            services.AddSingleton(mapper);
        }

        private IMapper ConfigureMapper()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommandsToGif());
                mc.AddProfile(new CommandsToUser());
                mc.AddProfile(new GifToGifDTO());
                mc.AddProfile(new UserToUserDTO());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
