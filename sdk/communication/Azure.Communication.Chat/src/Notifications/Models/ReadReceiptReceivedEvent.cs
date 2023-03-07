// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ReadReceiptReceivedEvent : ChatUserEvent
    {
        public string ChatMessageId { get; }

        public DateTime ReadOn { get; }

        public string MessageBody { get; }
    }
}
