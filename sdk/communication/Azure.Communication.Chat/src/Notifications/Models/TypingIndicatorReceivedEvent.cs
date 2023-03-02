using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class TypingIndicatorReceivedEvent
    {
        public string Version { get; set; }

        public DateTime ReceivedOn { get; set; }

        public String SenderDisplayName { get; set; }
    }
}
