using FreeBusy.Api.Filters;
using FreeBusy.Api.Services;
using FreeBusy.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FreeBusy.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDBCore, DBCore>();
            services.AddTransient<IFreeBusyService, FreeBusyService>();
            services.AddControllers(opt => opt.Filters.Add(typeof(FreeBusyExceptionFilter))).AddNewtonsoftJson();
            services.AddSwaggerGen(
                c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "FreeBusy.Api", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FreeBusy.Api v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        
    }
}
