using Publisher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publisher.Models
{
    internal class Configurations
    {
        public RabbitMQ RabbitMQ { get; set; }
        public MongoDB MongoDB { get; set; } = new MongoDB();

    }
}
