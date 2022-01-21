using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Subscriber.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Subscriber
{
    internal class ServiceSetup
    {

        static IConfiguration configs;
        
        public static IHostBuilder CreateHostBuilder()
        {
            

            configs = new ConfigurationBuilder()
                            .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                            .AddJsonFile("AppSettings.json")
                            .Build();
            return Host.CreateDefaultBuilder()
                        .ConfigureServices((context,services)=>
                            services.AddSingleton<MessageService>()
                            .AddSingleton(context.Configuration.Get<Configurations>())
                        )
                        .ConfigureAppConfiguration(conf =>
                        conf.AddConfiguration(configs));
        }
    }
}
