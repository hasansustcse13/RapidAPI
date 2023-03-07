using AUTH.API.Infrastructure;
using AUTH.Biz.BizEntities;
using AUTH.Biz.DBContext;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AUTH.API
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
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddDbContextPool<IAuthDBContext, AuthDbContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("AuthDbContext")));

            services.AddScoped<IAuthBizContext, AuthBizContext>(
                provider => AuthBizContext.Create(
                    provider.GetService<IAuthDBContext>(),
                    1,
                    provider.GetRequiredService<IHttpContextAccessor>().HttpContext.Connection.RemoteIpAddress.ToString()
                   ));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
