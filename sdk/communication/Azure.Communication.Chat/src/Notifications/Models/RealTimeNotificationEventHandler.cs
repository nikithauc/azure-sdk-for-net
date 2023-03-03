// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RealTimeNotificationEventHandler<T> where T : ChatEvent
    {
        /// <summary>
        /// EventHandler
        /// </summary>
        public event SyncAsyncEventHandler<T> ChatEventHandler;

        /// <summary>
        /// Invoke the event handler
        /// </summary>
        /// <param name="eventArguments"></param>
        public void InvokeEvent(T eventArguments)
        {
            ChatEventHandler.Invoke(eventArguments);
        }
    }
}
