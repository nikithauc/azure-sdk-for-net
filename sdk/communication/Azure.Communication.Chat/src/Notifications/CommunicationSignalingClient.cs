using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;
using Azure.Core;
using Microsoft.Trouter;

namespace Azure.Communication.Chat.Notifications
{
    public class CommunicationSignalingClient
    {
        private TrouterClient _trouterClient;
        private bool _isRealTimeNotificationsStarted;
        private Dictionary<ChatEventType, CommunicationListener> trouterListeners = new Dictionary<ChatEventType, CommunicationListener>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
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
        /// <returns></returns>
        private void CreateTrouterService()
        {
            _trouterClient = new TrouterClient(null, null);
        }

        public void on<T> (ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent
        {
            var listener = new CommunicationListener<T>(chatEventType.ToString(), realTimeNotificationEventHandler, eventArgs);
            _trouterClient.RegisterListener("", listener);
        }
    }
}
