// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Property
    /// </summary>
    public class ChatMessageEditedEvent : ChatUserEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public DateTime EditedOn { get; set; }

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

        /// <summary>
        /// Property
        /// </summary>
        public Dictionary<string, string> MetaData { get;} = new Dictionary<string, string>();
    }
}
