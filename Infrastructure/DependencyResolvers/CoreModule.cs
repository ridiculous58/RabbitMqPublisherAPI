using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Infrastructure.Helpers.Configurations;
using Infrastructure.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Elasticsearch(ElasticSearchConfiguration.Host)
            .CreateLogger();

            services.AddSingleton(Log.Logger);

        }
    }
}
