
using System.Collections.Generic;
using System;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ParticipantsRemovedEvent
    {
        public DateTime RemovedOn { get; set; }

        public ChatParticipant RemovedBy { get; set; }

        public List<ChatParticipant> ParticipantsRemoved { get; set; }
    }
}
