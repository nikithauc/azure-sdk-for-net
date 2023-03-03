// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
