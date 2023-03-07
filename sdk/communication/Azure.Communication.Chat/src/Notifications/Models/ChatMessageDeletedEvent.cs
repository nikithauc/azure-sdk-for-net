// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// model class
    /// </summary>
    public class ChatMessageDeletedEvent : ChatUserEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public DateTime DeletedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public string SenderDisplayName { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public string Version { get; set; }
    }
}
