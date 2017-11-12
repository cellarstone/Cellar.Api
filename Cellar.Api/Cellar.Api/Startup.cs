using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Cellar.Api.DataAccess.Api.Repository;
using Cellar.Api.DataAccess.Implementation.Repository;
using Cellar.Api.Business.Dummy.Api;
using Cellar.Api.Business.Reception.Api;
using Cellar.Api.Business.Dummy.Implementation;
using Cellar.Api.Business.Reception.Implementation;
using Cellar.Api.Business.Authentication.Api;
using Cellar.Api.Business.Authentication.Implementation;
using Cellar.Api.ActionFilters.Authentication;
using Cellar.Api.Business.Logging.Api;
using Cellar.Api.Business.Logging.Implementation;
using Cellar.Api.ActionFilters.Common;
using Cellar.Api.ActionFilters.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Cellar.Api
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
            services.AddMvc();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("CellarApi", new Info { Title = "CellarApi", Description = "Cellarston web API for meetroom kiosk", Version = "1.0.0", Contact = new Contact { Name = "Ondřej Snop - Cellarstone", Email = "ondrej.snop@cellarstone.cz" } });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddScoped<AuthenticatedRequestFilter>();
            services.AddScoped<ActionFilterBase>();
            services.AddScoped<LogActionFilter>();

            services.AddTransient<IDummyDataProvider, DummyDataProvider>();
            services.AddTransient<IReceptionManagement, ReceptionManagement>();
            services.AddTransient<ISortimentItemsRepository, SortimentItemsRepository>();
            services.AddTransient<IAuthenticationManagement, AuthenticationManagement>();
            services.AddTransient<IActionLogsRepository, ActionLogsRepository>();
            services.AddTransient<ILogManagement, LogManagement>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/documentation/swagger.json", "Cellar.Api v1.0.0");
            //});
        }
    }
}
