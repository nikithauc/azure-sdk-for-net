// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Chat.Notifications.Models
{
    public class ParticipantsAddedEvent : ChatThreadEvent
    {
        public DateTime AddedOn { get; set; }

        public ChatParticipant AddedBy { get; set; }

        private List<ChatParticipant> _participantAdded;

        public List<ChatParticipant> ParticipantsAdded
        {
            get { return _participantAdded; }
            set
            {
                if (_participantAdded == null)
                {
                    _participantAdded = new List<ChatParticipant> { value };
                }
                else
                { }
            }
        }
    }
}
