// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatThreadPropertiesUpdatedEvent : ChatThreadEvent
    {
        public ChatThreadProperties Properties { get; set; }

        public DateTime UpdatedOn { get; set; }

        public ChatParticipant UpdatedBy { get; set; }
    }
}
