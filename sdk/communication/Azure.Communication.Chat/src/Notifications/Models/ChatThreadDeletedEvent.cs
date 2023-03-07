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
    public class ChatThreadDeletedEvent : ChatThreadEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public DateTime DeletedOn { get; set; }


        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant DeletedBy { get; set; }
    }
}
