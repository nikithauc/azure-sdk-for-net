using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public sealed class ChatMessageType
    {
        private ChatMessageType(string value) { Value = value; }

        public string Value { get; private set; }

        public static ChatMessageType TEXT { get { return new ChatMessageType("text"); } }
        public static ChatMessageType HTML { get { return new ChatMessageType("html"); } }
        public static ChatMessageType TOPIC_UPDATED { get { return new ChatMessageType("topicUpdated"); } }
        public static ChatMessageType PARTICIPANT_ADDED { get { return new ChatMessageType("participantAdded"); } }
        public static ChatMessageType PARTICIPANT_REMOVED { get { return new ChatMessageType("participantRemoved"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
