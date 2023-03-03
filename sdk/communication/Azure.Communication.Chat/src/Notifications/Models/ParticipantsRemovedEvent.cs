// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ParticipantsRemovedEvent : ChatThreadEvent
    {
        public DateTime RemovedOn { get; set; }

        public ChatParticipant RemovedBy { get; set; }

        public List<ChatParticipant> ParticipantsRemoved { get; set; }
    }
}
