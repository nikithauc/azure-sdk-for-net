using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TypingIndicatorReceivedEvent
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
