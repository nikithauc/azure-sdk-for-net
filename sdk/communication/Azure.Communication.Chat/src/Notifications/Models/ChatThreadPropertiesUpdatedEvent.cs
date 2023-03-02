using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatThreadPropertiesUpdatedEvent : ChatThreadEvent
    {
        public ChatThreadProperties Properties { get; set; }

        public DateTime UpdatedOn { get; set; }

        public ChatParticipant UpdatedBy { get; set; }
    }
}
