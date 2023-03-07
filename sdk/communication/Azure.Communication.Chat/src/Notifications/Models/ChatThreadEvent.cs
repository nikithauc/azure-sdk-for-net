// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Property
    /// </summary>
    public abstract class ChatThreadEvent
    {
        /// <summary>
        /// Property
        /// </summary>
        public string Version { get; set; }
    }
}
