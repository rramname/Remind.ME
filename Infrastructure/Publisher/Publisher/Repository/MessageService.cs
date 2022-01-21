using Newtonsoft.Json;
using Publisher.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publisher
{
    internal class MessageService :IMessageService
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
        public bool Enqueue(List<Birthday> data)
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
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                    channel.BasicPublish(String.Empty,
                                        configurations.RabbitMQ.Queue,
                                        null,
                                        body);
                    Console.WriteLine(" [x] Published {0} to RabbitMQ", JsonConvert.SerializeObject(body));
                   
                }
            }

            return true;
            //var message = new MessageObject { Message = "Happy Bday", ReminderAbout = "Birthday", ToEmail = "me@nowhere.com" };

        }
    }
}
