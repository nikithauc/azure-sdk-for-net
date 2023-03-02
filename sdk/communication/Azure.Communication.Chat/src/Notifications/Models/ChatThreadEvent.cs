using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public abstract class ChatThreadEvent : ChatEvent
    {
        public string Version { get; set; }
    }
}
