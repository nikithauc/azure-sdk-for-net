// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    ///
    /// </summary>
    public class TypingIndicatorReceivedEvent: ChatUserEvent
    {
        /// <summary>
        ///
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime ReceivedOn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public String SenderDisplayName { get; set; }
    }
}
