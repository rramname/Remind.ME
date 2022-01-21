using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subscriber.Models;
using RabbitMQ.Client;
using System;

namespace Subscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var provider = ServiceSetup.CreateHostBuilder().Build();
            var msgService= provider.Services.GetService<MessageService>();
            msgService.Dequeue();

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
