﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber.Models
{
    internal class RabbitMQ
    {
        public string HostName { get; set; }   
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string Queue { get; set; }

    }
}
