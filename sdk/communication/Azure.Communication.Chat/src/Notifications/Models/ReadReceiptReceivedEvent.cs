// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ReadReceiptReceivedEvent : ChatUserEvent
    {
        public string ChatMessageId { get; set; }

        public DateTime ReadOn { get; set; }

        public string MessageBody { get; set; }
    }
}
