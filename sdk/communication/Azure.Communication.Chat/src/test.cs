// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;
using Azure.Core;

namespace Azure.Communication.Chat
{
    internal class test
    {
        internal static async Task createClient() {

            var chatClient = new ChatClient( new System.Uri(""), null);
            var chatClient = new ChatClient(endpoint, communicationTokenCredential);

            /**
             * Start the real time notification handler
             * * The realTimeNotificationHandler contains the eventHandlers to be set by the client apps.
             **/
            var realTimeNotificationHandler = await chatClient.StartRealTimeNotifications().ConfigureAwait(false);

            // Set the custom implementation to the event handler
            realTimeNotificationHandler.ChatThreadCreated += (ChatThreadCreatedEvent e) =>
            {
                Console.WriteLine($"A Chat thread is created with id {e.ThreadId}");
                return Task.CompletedTask;
            };

            // use the `on` method to subscribe to the event.
            chatClient.On(ChatEventType.ChatMessageReceived);

            // use the `off` method to unsubscribe from the event.
            chatClient.Off(ChatEventType.ChatMessageReceived);
        }
    }
}
