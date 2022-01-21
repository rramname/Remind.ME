using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Publisher.Models;
using PublisherService;
using PublisherService.Models;
using PublisherService.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Publisher
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
                            services.AddSingleton<IMessageService,MessageService>()
                            .AddSingleton(context.Configuration.Get<Configurations>())
                            .AddSingleton<BirthdayContext>()
                            .AddSingleton<IBirthdayRepository,BirthdayRepository>()
                        )
                        .ConfigureAppConfiguration(conf =>
                        conf.AddConfiguration(configs));
        }
    }
}
