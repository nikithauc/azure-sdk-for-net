
using System;

namespace Azure.Communication.Chat.Notifications.Models
{
    public abstract class ChatUserEvent: ChatEvent
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
