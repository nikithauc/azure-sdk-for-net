using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatMessageEditedEvent : ChatUserEvent
    {
        public string Content { get; set; }

        public DateTime EditedOn { get; set; }

        public string Id { get; set; }

        public string SenderDisplayName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Version { get; set; }

        public HashSet<string, string> MetaData { get; set; }
    }
}
