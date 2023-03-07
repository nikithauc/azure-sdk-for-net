// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Moddel Class
    /// </summary>
    public class ParticipantsRemovedEvent : ChatThreadEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public DateTime RemovedOn { get;  }

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant RemovedBy { get; }

        /// <summary>
        /// Property
        /// </summary>
        public List<ChatParticipant> ParticipantsRemoved { get; } = new List<ChatParticipant> ();
    }
}
