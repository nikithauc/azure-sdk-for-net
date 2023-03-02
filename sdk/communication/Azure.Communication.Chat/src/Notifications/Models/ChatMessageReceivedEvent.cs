using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatMessageReceivedEvent
    {

        public ChatMessageType Type { get; set; }

        public string MessageType { get; set; }

        public string Content { get; set; }

        public string Priority { get; set; }
    }
}
