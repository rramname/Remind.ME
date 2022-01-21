using Newtonsoft.Json;
using Subscriber.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Events;

namespace Subscriber
{
    internal class MessageService
    {
        Configurations configurations;
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;
        public MessageService(IServiceProvider provider)
        {
            
            configurations=(Configurations)provider.GetService(typeof(Configurations));
            Console.WriteLine("about to connect to rabbit " + configurations.RabbitMQ.HostName);
            Console.WriteLine("about to connect to port " + configurations.RabbitMQ.Port);

            _factory = new ConnectionFactory() { HostName = configurations.RabbitMQ.HostName, Port = configurations.RabbitMQ.Port };
            _factory.UserName = configurations.RabbitMQ.UserName;
            _factory.Password = configurations.RabbitMQ.Password;
        }
        public void Dequeue()
        {
            using (var con=_factory.CreateConnection())
            {
                using(IModel channel = con.CreateModel())
                {
                    channel.QueueDeclare(queue: configurations.RabbitMQ.Queue,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false
                                    );
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: configurations.RabbitMQ.Queue,
                                         autoAck: true,
                                         consumer: consumer);
                   
                }
            }

            //var message = new MessageObject { Message = "Happy Bday", ReminderAbout = "Birthday", ToEmail = "me@nowhere.com" };

        }
    }
}
