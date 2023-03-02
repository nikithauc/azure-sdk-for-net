using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatThreadDeletedEvent : ChatThreadEvent
    {
        public DateTime DeletedOn { get; set; }

        public ChatParticipant DeletedBy { get; set; }
    }
}
