// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public abstract class ChatUserEvent
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private string senderId { get; set; }
        private string recipientMri { get; set; }
        private string recipientId { get; set; }
        private CommunicationIdentifier sender { get; set; }
        private CommunicationIdentifier recipient { get; set; }
        private MicrosoftTeamsUserIdentifierModel microsoftTeamsUser { get; set; }
        private PhoneNumberIdentifierModel phoneNumber { get; set; }
        private CommunicationUserIdentifierModel communicationUser { get; set; }
    }
}
