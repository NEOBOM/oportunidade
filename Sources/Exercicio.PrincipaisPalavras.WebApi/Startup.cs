using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicio.PrincipaisPalavras.Application.BlogMinutoSeguro;
using Exercicio.PrincipaisPalavras.Application.BlogMinutoSeguro.Interfaces;
using Exercicio.PrincipaisPalavras.Infra.HttpService;
using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Exercicio.PrincipaisPalavras.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Http Services
            services.AddSingleton<IBlogMinutoSeguroService, BlogMinutoSeguroHttpService>();

            //Application
            services.AddSingleton<IBlogMinutoSeguroApp, BlogMinutoSeguroApp>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
