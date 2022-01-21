using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber.Models
{
    internal class MessageObject
    {
        public string ToEmail { get; set; }
        public string Message { get; set; }

        public string ReminderAbout { get; set; }
    }
}
