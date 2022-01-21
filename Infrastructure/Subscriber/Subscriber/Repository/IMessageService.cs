using Subscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber
{
    internal interface IMessageService
    {
        bool Receive();
    }
}
