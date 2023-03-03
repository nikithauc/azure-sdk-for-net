### Example Usage:

```cs
public class Sample{
    public static void Main()
    {
        var chatClient = new ChatClient();

        var realTimeNotificationHandler = new RealTimeNotificationHandler();
        realTimeNotificationHandler.ChatEventHandler += ChatMessageReceivedHandler;

        chatClient.startRealTimeNotifications();
        chatClient.AddEventHandler(ChatEventType.CHAT_MESSAGE_RECEIVED,realTimeNotificationHandler)
    }
    public static void ChatMessageReceivedHandler(ChatMessageReceivedEvent args)
    {
        Console.WriteLine("Process Completed!");
    }
}
```

## Existing Class:

```cs
public class ChatClient
{
    public ChatClient(Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default);

    // Following are the newly added methods
    public async Task StartRealTimeNotifications();

    public async Task StopRealTimeNotifications();

    public void AddEventHandler<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent

    public void AddEventHandler<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent

    public void RemoveEventHandler<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent
```
## New Classes:

### Model Classes

*RealTimeNotificationEventHandler.cs*
```cs
public class RealTimeNotificationEventHandler<T> where T : ChatEvent
{
    public event SyncAsyncEventHandler<T> ChatEventHandler;
    public void InvokeEvent(T eventArguments);
}
```

*ChatEvent.cs*
```cs
public abstract class ChatEvent : SyncAsyncEventArgs{
     protected ChatEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken);

     public string ThreadId { get; set; }
     public string GroupId { get; set; }
}
```

*ChatEventType.cs*
```cs
public sealed class ChatEventType
    {
        private ChatEventType(string value) { Value = value; }
        public string Value { get; private set; }

        public static ChatEventType CHAT_MESSAGE_RECEIVED { get { return new ChatEventType("chatMessageReceived"); } }
        public static ChatEventType CHAT_MESSAGE_EDITED { get { return new ChatEventType("chatMessageEdited"); } }
        public static ChatEventType CHAT_MESSAGE_DELETED { get { return new ChatEventType("chatMessageDeleted"); } }
        public static ChatEventType TYPING_INDICATOR_RECEIVED { get { return new ChatEventType("typingIndicatorReceived"); } }
        public static ChatEventType READ_RECEIPT_RECEIVED { get { return new ChatEventType("readReceiptReceived"); } }
        public static ChatEventType CHAT_THREAD_CREATED { get { return new ChatEventType("chatThreadCreated"); } }
        public static ChatEventType CHAT_THREAD_DELETED { get { return new ChatEventType("chatThreadDeleted"); } }
        public static ChatEventType CHAT_THREAD_PROPERTIES_UPDATED { get { return new ChatEventType("chatThreadPropertiesUpdated"); } }
        public static ChatEventType PARTICIPANTS_ADDED { get { return new ChatEventType("participantsAdded"); } }
        public static ChatEventType PARTICIPANTS_REMOVED { get { return new ChatEventType("participantsRemoved"); } }

        public override string ToString()
        {
            return Value;
        }
    }
```

*ChatUserEvent.cs*
```cs
public abstract class ChatUserEvent : ChatEvent
{
    private string senderId { get; set; }
    private string recipientMri { get; set; }
    private string recipientId { get; set; }
    private CommunicationIdentifier sender { get; set; }
    private CommunicationIdentifier recipient { get; set; }
    private MicrosoftTeamsUserIdentifierModel microsoftTeamsUser { get; set; }
    private PhoneNumberIdentifierModel phoneNumber { get; set; }
    private CommunicationUserIdentifierModel communicationUser { get; set; }
}
```

*ChatMessageDeletedEvent.cs*
```cs
public class ChatMessageDeletedEvent : ChatUserEvent
{
    public DateTime DeletedOn { get; set; }

    public string Id { get; set; }

    public string SenderDisplayName { get; set; }

    public DateTime CreatedOn { get; set; }

    public string Version { get; set; }
}
```

*ChatMessageEditedEvent.cs*
```cs
public class ChatMessageEditedEvent : ChatUserEvent
{
    public string Content { get; set; }

    public DateTime EditedOn { get; set; }

    public string Id { get; set; }

    public string SenderDisplayName { get; set; }

    public DateTime CreatedOn { get; set; }

    public string Version { get; set; }

    public Dictionary<string, string> MetaData { get; set; }
}
```

*ChatThreadEvent.cs*
```cs
public abstract class ChatThreadEvent : ChatEvent
{
    public string Version { get; set; }
}
```

*ChatThreadCreatedEvent.cs*
```cs
public class ChatThreadCreatedEvent : ChatThreadEvent
{
    public DateTime CreatedOn { get; set; }

    public ChatThreadProperties Properties { get; set; }

    public List<ChatParticipant> Participants { get; set; }

    public ChatParticipant CreatedBy { get; set; }
}
```

*ChatThreadDeletedEvent.cs*
```cs
public class ChatThreadDeletedEvent : ChatThreadEvent
{
    public DateTime DeletedOn { get; set; }

    public ChatParticipant DeletedBy { get; set; }
}
```

*ChatThreadPropertiesUpdatedEvent.cs*
```cs
public class ChatThreadPropertiesUpdatedEvent : ChatThreadEvent
{
    public ChatThreadProperties Properties { get; set; }

    public DateTime UpdatedOn { get; set; }

    public ChatParticipant UpdatedBy { get; set; }
}
```

*ParticipantsAddedEvent.cs*
```cs
public class ParticipantsAddedEvent : ChatThreadEvent
{
    public DateTime AddedOn { get; set; }

    public ChatParticipant AddedBy { get; set; }

    private List<ChatParticipant> _participantAdded;

    public List<ChatParticipant> ParticipantsAdded;
}
```

*ParticipantsRemovedEvent.cs*
```cs
public class ParticipantsRemovedEvent : ChatThreadEvent
{
    public DateTime RemovedOn { get; set; }

    public ChatParticipant RemovedBy { get; set; }

    public List<ChatParticipant> ParticipantsRemoved { get; set; }
}
```

*ReadReceiptReceivedEvent.cs*
```cs
public class ReadReceiptReceivedEvent : ChatUserEvent
{
    public string ChatMessageId { get; set; }

    public DateTime ReadOn { get; set; }

    public string MessageBody { get; set; }
}
```

*TypingIndicatorReceivedEvent.cs*
```cs
public class TypingIndicatorReceivedEvent: ChatUserEvent
{
        public string Version { get; set; }

        public DateTime ReceivedOn { get; set; }

        public String SenderDisplayName { get; set; }
}
```

### Internal classes
```cs
internal class CommunicationSignalingClient
{
    public async Task Start();
    public async Task Stop();

    public void on<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent;

    public void off<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent
}

internal class CommunicationListener<T> : TrouterListener where T : ChatEvent
{
    public override Task<TrouterResponse> ProcessRequestAsync(TrouterRequest request, CancellationToken cancellationToken = default);
}
```



