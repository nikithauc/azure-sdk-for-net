// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Trouter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace Azure.Communication.Chat.Tests.ChatClients
{
    [TestClass]
    internal class TrouterClientTest
    {
        private sealed class TestSkypetokenCredential : SkypetokenCredential
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            public override async Task<Skypetoken> GetTokenAsync(CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                var token = "";
                return new Skypetoken(token);
            }
        }

        private sealed class TestMessageListener : TrouterListener
        {
            private readonly string _replyPrefix;

            public TestMessageListener(string replyPrefix) => _replyPrefix = replyPrefix;

            public override Task<TrouterResponse> ProcessRequestAsync(TrouterRequest request, CancellationToken cancellationToken = default)
            {
                var requestBody = request.Body.ToString();
                return Task.FromResult(new TrouterResponse { Body = new BinaryData(_replyPrefix + requestBody) });
            }
        }

        [TestMethod]
        public async Task TestAllocationAndForwarding()
        {
            var options = new TrouterClientOptions
            {
                TrouterHostName = "go.trouter.skype.com",
                ApplicationName = "Microsoft.Trouter.Tests",
                RegistrarHostName = "edge.skype.com/registrar/prod/v3/registrations",
                RegistrationOptions = new RegistrationOptions
                {
                    PnhAppId = "AcsWeb",
                    PnhTemplate = "AcsWeb_Chat_1.5",
                    PlatformId = "SPOOL",
                    PlatformUiVersion = "0.0.0"
                }
            };

            var credential = new TestSkypetokenCredential();
            var client = new TrouterClient(credential, options);
            client.Connected += OnTrouterClientConnected;
            client.RegisterListener("/chat", new TestMessageListener("hello"));
            client.RegisterListener("/hello2", new TestMessageListener("hello2"));

            TrouterConnectedEventArgs connectionArgs = await client.StartAsync().ConfigureAwait(false);

            var response1 = await SendTestMessage(connectionArgs.BaseEndpoint + "chat", "foo").ConfigureAwait(false);
            response1.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseContent1 = await response1.Content.ReadAsStringAsync().ConfigureAwait(false);
            responseContent1.Should().Be("hellofoo");

            var response2 = await SendTestMessage(connectionArgs.BaseEndpoint + "hello2", "bar").ConfigureAwait(false);
            response2.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseContent2 = await response2.Content.ReadAsStringAsync().ConfigureAwait(false);
            responseContent2.Should().Be("hello2bar");

            await client.StopAsync().ConfigureAwait(false);
        }

        private static async Task<HttpResponseMessage> SendTestMessage(string uri, string text)
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(text)
                });

            var content = new StringContent(text);
            content.Headers.Add("Trouter-Request", "{}");
            var httpClient = new HttpClient(mockHandler.Object);
            var response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);
            return response;
        }

        private Task OnTrouterClientConnected(TrouterConnectedEventArgs arg)
        {
            return Task.CompletedTask;
        }
    }
}
