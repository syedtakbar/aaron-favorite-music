using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using aaron_favorite_music_data;
using Microsoft.EntityFrameworkCore;

namespace aaron_favorite_music
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
            services.AddDbContextPool<MusicAlbumDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("FavoriteMusic"));
            });


            services.AddScoped<IMusicAlbum, SqlMusicAlbumData>();
            //services.AddSingleton<IMusicAlbum, InMemoryData>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.Use ( (ctx ,next) => 
            {               
                if (ctx.Request.Path.StartsWithSegments("/hello-Aaron"))
                {
                    return ctx.Response.WriteAsync("Hi from middleware!!");      
                } 
                else
                {
                    return next();   
                }
            } );

            app.UseMvc();
        }
    }
}
