// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications;
using Azure.Communication.Chat.Notifications.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// The Azure Communication Services Chat client.
    /// </summary>
    public class ChatClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ChatRestClient _chatRestClient;
        private readonly Uri _endpointUrl;
        private readonly CommunicationTokenCredential _communicationTokenCredential;
        private readonly ChatClientOptions _chatClientOptions;
        private readonly CommunicationSignalingClient _communicationSignalingClient;

        /// <summary> Initializes a new instance of <see cref="ChatClient"/>.</summary>
        /// <param name="endpoint">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ChatClient(Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default)
        {
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            _chatClientOptions = options ?? new ChatClientOptions();
            _communicationTokenCredential = communicationTokenCredential;
            _endpointUrl = endpoint;
            _clientDiagnostics = new ClientDiagnostics(_chatClientOptions);
            HttpPipeline pipeline = CreatePipelineFromOptions(_chatClientOptions, communicationTokenCredential);
            _chatRestClient = new ChatRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, _chatClientOptions.ApiVersion);
            _communicationSignalingClient = new CommunicationSignalingClient();
        }

        /// <summary>Initializes a new instance of <see cref="ChatClient"/> for mocking.</summary>
        protected ChatClient()
        {
            _clientDiagnostics = null!;
            _chatRestClient = null!;
            _endpointUrl = null!;
            _communicationTokenCredential = null!;
            _chatClientOptions = null!;
        }

        #region Thread Operations
        /// <summary>Creates a ChatThreadClient asynchronously. <see cref="ChatThreadClient"/>.</summary>
        /// <param name="topic">Topic for the chat thread</param>
        /// <param name="participants">Participants to be included in the chat thread</param>
        /// <param name="idempotencyToken"> If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-ID and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-ID is an opaque string representing a client-generated, globally unique for all time, identifier for the request. It is recommended to use version 4 (random) UUIDs. </param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CreateChatThreadResult>> CreateChatThreadAsync(string topic, IEnumerable<ChatParticipant> participants = null, string idempotencyToken = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(CreateChatThread)}");
            scope.Start();
            try
            {
                idempotencyToken ??= Guid.NewGuid().ToString();
                Response<CreateChatThreadResultInternal> createChatThreadResultInternal = await _chatRestClient.CreateChatThreadAsync(topic, idempotencyToken, participants.Select(x => x.ToChatParticipantInternal()), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CreateChatThreadResult(createChatThreadResultInternal.Value), createChatThreadResultInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Creates a ChatThreadClient synchronously.<see cref="ChatThreadClient"/>.</summary>
        /// <param name="topic">Topic for the chat thread</param>
        /// <param name="participants">Participants to be included in the chat thread</param>
        /// <param name="idempotencyToken"> If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-ID and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-ID is an opaque string representing a client-generated, globally unique for all time, identifier for the request. It is recommended to use version 4 (random) UUIDs. </param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CreateChatThreadResult> CreateChatThread(string topic, IEnumerable<ChatParticipant> participants, string idempotencyToken = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(CreateChatThread)}");
            scope.Start();
            try
            {
                idempotencyToken ??= Guid.NewGuid().ToString();
                Response<CreateChatThreadResultInternal> createChatThreadResultInternal = _chatRestClient.CreateChatThread(topic, idempotencyToken, participants.Select(x => x.ToChatParticipantInternal()), cancellationToken);
                return Response.FromValue(new CreateChatThreadResult(createChatThreadResultInternal.Value), createChatThreadResultInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of ChatThreadClient. <see cref="ChatThreadClient"/>.</summary>
        /// <param name="threadId"> The thread id for the ChatThreadClient instance. </param>
        public virtual ChatThreadClient GetChatThreadClient(string threadId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreadClient)}");
            scope.Start();
            try
            {
                return new ChatThreadClient(threadId, _endpointUrl, _communicationTokenCredential, _chatClientOptions);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the list of chat threads of a user<see cref="ChatThreadItem"/> asynchronously.</summary>
        /// <param name="startTime"> The earliest point in time to get chat threads up to. The timestamp should be in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ChatThreadItem> GetChatThreadsAsync(DateTimeOffset? startTime = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ChatThreadItem>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreads)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsItemCollection> response = await _chatRestClient.ListChatThreadsAsync(pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ChatThreadItem>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreads)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsItemCollection> response = await _chatRestClient.ListChatThreadsNextPageAsync(nextLink, pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the list of chat threads of a user<see cref="ChatThreadItem"/>.</summary>
        /// <param name="startTime"> The earliest point in time to get chat threads up to. The timestamp should be in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ChatThreadItem> GetChatThreads(DateTimeOffset? startTime = null, CancellationToken cancellationToken = default)
        {
            Page<ChatThreadItem> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreads)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsItemCollection> response = _chatRestClient.ListChatThreads(pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ChatThreadItem> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreads)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsItemCollection> response = _chatRestClient.ListChatThreadsNextPage(nextLink, pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Deletes a thread asynchronously. </summary>
        /// <param name="threadId"> Thread id to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteChatThreadAsync(string threadId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(DeleteChatThread)}");
            scope.Start();
            try
            {
                return await _chatRestClient.DeleteChatThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a thread. </summary>
        /// <param name="threadId"> Thread id to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteChatThread(string threadId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(DeleteChatThread)}");
            scope.Start();
            try
            {
                return _chatRestClient.DeleteChatThread(threadId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion

        private static HttpPipeline CreatePipelineFromOptions(ChatClientOptions options, CommunicationTokenCredential communicationTokenCredential)
        {
            var bearerTokenCredential = new CommunicationBearerTokenCredential(communicationTokenCredential);
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(bearerTokenCredential, "");
            return HttpPipelineBuilder.Build(options, authenticationPolicy);
        }

        //Check how the following fits.

        //public event SyncAsyncEventHandler<ChatMessageReceivedEvent> ChatMessageReceived;
        //public event SyncAsyncEventHandler<ChatMessageEditedEvent> ChatMessageEdited;
        //public event SyncAsyncEventHandler<ChatMessageDeletedEvent> ChatMessageDeleted;
        //public event SyncAsyncEventHandler<TypingIndicatorReceivedEvent> TypingIndicatorReceived;
        //public event SyncAsyncEventHandler<ReadReceiptReceivedEvent> ReadReceiptReceived;
        //public event SyncAsyncEventHandler<ChatThreadCreatedEvent> ChatThreadCreated;
        //public event SyncAsyncEventHandler<ChatThreadDeletedEvent> ChatThreadDeleted;
        //public event SyncAsyncEventHandler<ChatThreadPropertiesUpdatedEvent> ChatThreadPropertiesUpdated;
        //public event SyncAsyncEventHandler<ParticipantsAddedEvent> ParticipantsAdded;
        //public event SyncAsyncEventHandler<ParticipantsRemovedEvent> ParticipantsRemoved;

        /// <summary>
        /// Start trouter client
        /// </summary>
        /// <returns></returns>
        public async Task StartRealTimeNotifications()
        {
            await _communicationSignalingClient.Start().ConfigureAwait(false);
        }

        /// <summary>
        /// Stop trouter stop
        /// </summary>
        /// <returns></returns>
        public async Task StopRealTimeNotifications()
        {
            await _communicationSignalingClient.Stop().ConfigureAwait(false);
        }

        /// <summary>
        /// Set the custom Handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="chatEventType"></param>
        /// <param name="realTimeNotificationEventHandler"></param>
        /// <param name="eventArgs"></param>
        public void AddEventHandler<T>(ChatEventType chatEventType, RealTimeNotificationEventHandler<T> realTimeNotificationEventHandler, T eventArgs) where T : ChatEvent
        {
            _communicationSignalingClient.on<T>(chatEventType, realTimeNotificationEventHandler, eventArgs);
        }

        /// <summary>
        /// Remove the event handler for a given event
        /// </summary>
        /// <param name="chatEventType"></param>
        public void RemoveEventHandler(ChatEventType chatEventType)
        {
        }
    }
}
