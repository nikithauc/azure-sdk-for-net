using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;
using Azure.Core;
using Microsoft.Trouter;

namespace Azure.Communication.Chat.Notifications
{
    public class CommunicationListener<T> : TrouterListener where T : ChatEvent
    {
        private string _eventType;
        private RealTimeNotificationEventHandler<T> _realTimeNotificationEventHandler;
        private T _eventArgs;


        /// <summary>
        /// Implementation of TrouterListener
        /// </summary>
        /// <param name="chatEventType"></param>
        /// <param name="realTimeNotificationEventHandler"></param>
        /// <param name="eventArgs"></param>
        public CommunicationListener(string chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs)
        {
            _eventType = chatEventType;
            _realTimeNotificationEventHandler = realTimeNotificationEventHandler;
            _eventArgs = eventArgs;
        }

        public override Task<TrouterResponse> ProcessRequestAsync(TrouterRequest request, CancellationToken cancellationToken = default)
        {
            // call the event handler here
            await _realTimeNotificationEventHandler.InvokeEvent(_eventArgs);
        }
    }
}

