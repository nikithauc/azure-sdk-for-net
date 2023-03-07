// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// model class
    /// </summary>
    public class ParticipantsAddedEvent : ChatThreadEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public DateTime AddedOn { get;}

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant AddedBy { get; }

        /// <summary>
        /// Property
        /// </summary>
        public List<ChatParticipant> ParticipantsAdded { get; } = new List<ChatParticipant>();
    }
}
