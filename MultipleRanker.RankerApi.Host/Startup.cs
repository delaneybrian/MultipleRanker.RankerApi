using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultipleRanker.RankerApi.Host.Infastructure.IoC;

namespace MultipleRanker.RankerApi.Host
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var container = Bootstrapper.Bootstrap(services);

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
