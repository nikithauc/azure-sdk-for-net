// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ParticipantsAddedEvent
    {
        public  DateTime AddedOn { get; set; }

        public  ChatParticipant AddedBy { get; set; }

        public List<ChatParticipant> ParticipantsAdded { get; set; }
    }
}
