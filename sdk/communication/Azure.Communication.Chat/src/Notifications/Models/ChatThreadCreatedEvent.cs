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
    public class ChatThreadCreatedEvent : ChatThreadEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public ChatThreadProperties Properties { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public List<ChatParticipant> Participants { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant CreatedBy { get; set; }
    }
}
