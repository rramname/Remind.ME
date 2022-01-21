using Publisher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publisher
{
    internal interface IMessageService
    {
        bool Enqueue(List<Birthday> data );
    }
}
