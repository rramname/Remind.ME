using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Publisher.Models;
using PublisherService.Repository;
using RabbitMQ.Client;
using System;
using System.Threading;

namespace Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var provider = ServiceSetup.CreateHostBuilder().Build();
            var msgService= provider.Services.GetService<IMessageService>();
            var brepo = provider.Services.GetService<IBirthdayRepository>();
            while (true)
            {
                var data = brepo.GetAll();
                msgService.Enqueue(data);
                Thread.Sleep(5000);
            }

        }
        private static void ConfigureServices()
        {
            Configurations configs = new Configurations();
            IConfiguration config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
        
            configs= (Configurations)config.GetSection("RabbitMQ");
        }
    }
}
