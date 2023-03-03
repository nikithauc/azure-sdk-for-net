// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatMessageDeletedEvent : ChatUserEvent
    {
        public DateTime DeletedOn { get; set; }

        public string Id { get; set; }

        public string SenderDisplayName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Version { get; set; }
    }
}
