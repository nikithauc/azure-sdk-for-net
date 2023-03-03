// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    public sealed class ChatEventType
    {
        private ChatEventType(string value) { Value = value; }
        public string Value { get; private set; }

        public static ChatEventType CHAT_MESSAGE_RECEIVED { get { return new ChatEventType("chatMessageReceived"); } }
        public static ChatEventType CHAT_MESSAGE_EDITED { get { return new ChatEventType("chatMessageEdited"); } }
        public static ChatEventType CHAT_MESSAGE_DELETED { get { return new ChatEventType("chatMessageDeleted"); } }
        public static ChatEventType TYPING_INDICATOR_RECEIVED { get { return new ChatEventType("typingIndicatorReceived"); } }
        public static ChatEventType READ_RECEIPT_RECEIVED { get { return new ChatEventType("readReceiptReceived"); } }
        public static ChatEventType CHAT_THREAD_CREATED { get { return new ChatEventType("chatThreadCreated"); } }
        public static ChatEventType CHAT_THREAD_DELETED { get { return new ChatEventType("chatThreadDeleted"); } }
        public static ChatEventType CHAT_THREAD_PROPERTIES_UPDATED { get { return new ChatEventType("chatThreadPropertiesUpdated"); } }
        public static ChatEventType PARTICIPANTS_ADDED { get { return new ChatEventType("participantsAdded"); } }
        public static ChatEventType PARTICIPANTS_REMOVED { get { return new ChatEventType("participantsRemoved"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
