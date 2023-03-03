// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatThreadCreatedEvent : ChatThreadEvent
    {
        public DateTime CreatedOn { get; set; }

        public ChatThreadProperties Properties { get; set; }

        public List<ChatParticipant> Participants { get; set; }

        public ChatParticipant CreatedBy { get; set; }
    }
}
