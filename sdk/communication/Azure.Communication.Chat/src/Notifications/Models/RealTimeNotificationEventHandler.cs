// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    ///
    /// </summary>
    //./ <typeparam name="T"></typeparam>
    public class RealTimeNotificationEventHandler<T> where T : ChatEvent
    //public class RealTimeNotificationEventHandler
    {
        /// <summary>
        /// EventHandler
        /// </summary>
        public event SyncAsyncEventHandler<T> ChatEventHandler;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ChatMessageReceivedEvent> ChatMessageReceived;

        ///// <summary>
        ///// EventHandler
        ///// </summary
        //public event SyncAsyncEventHandler<ChatMessageEditedEvent> ChatMessageEdited;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ChatMessageDeletedEvent> ChatMessageDeleted;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<TypingIndicatorReceivedEvent> TypingIndicatorReceived;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ReadReceiptReceivedEvent> ReadReceiptReceived;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ChatThreadCreatedEvent> ChatThreadCreated;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ChatThreadDeletedEvent> ChatThreadDeleted;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ChatThreadPropertiesUpdatedEvent> ChatThreadPropertiesUpdated;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ParticipantsAddedEvent> ParticipantsAdded;

        ///// <summary>
        ///// EventHandler
        ///// </summary>
        //public event SyncAsyncEventHandler<ParticipantsRemovedEvent> ParticipantsRemoved;

        /// <summary>
        /// Invoke the event handler
        /// </summary>
        /// <param name="eventArguments"></param>
        public async Task InvokeEvent(T eventArguments)
        {
           await ChatEventHandler.Invoke(eventArguments).ConfigureAwait(false);
        }
    }
}
