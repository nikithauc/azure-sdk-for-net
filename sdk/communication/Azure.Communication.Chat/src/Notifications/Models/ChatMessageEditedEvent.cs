// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        public Dictionary<string, string> MetaData { get; set; }
    }
}
