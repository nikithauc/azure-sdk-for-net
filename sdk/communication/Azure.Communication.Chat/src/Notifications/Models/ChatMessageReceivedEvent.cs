// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Property
    /// </summary>
    public class ChatMessageReceivedEvent: ChatUserEvent
    {

        /// <summary>
        /// Property
        /// </summary>
        public ChatMessageType Type { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public string Priority { get; set; }
    }
}
