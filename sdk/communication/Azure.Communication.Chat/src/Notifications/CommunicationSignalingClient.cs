// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;
using Microsoft.Trouter;

namespace Azure.Communication.Chat.Notifications
{
    internal class CommunicationSignalingClient: IDisposable
    {
        private TrouterClient _trouterClient;
        private bool _isRealTimeNotificationsStarted;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            await _trouterClient.StartAsync().ConfigureAwait(false);
            _isRealTimeNotificationsStarted = true;
            CreateTrouterService();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task Stop()
        {
            if (!_isRealTimeNotificationsStarted)
            {
                return;
            }
            await _trouterClient.StopAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        private void CreateTrouterService()
        {
            _trouterClient = new TrouterClient(null, null);
        }

        public void on<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent
        {
            var listener = new CommunicationListener<T>(chatEventType.ToString(), realTimeNotificationEventHandler, eventArgs);
            _trouterClient.RegisterListener("", listener);
        }

        public void off<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent
        {
            //_trouterClient.RegisterListener("", realTimeNotificationEventHandler);
        }
        public void Dispose()
        {
            _trouterClient.Dispose();
        }
    }
}
