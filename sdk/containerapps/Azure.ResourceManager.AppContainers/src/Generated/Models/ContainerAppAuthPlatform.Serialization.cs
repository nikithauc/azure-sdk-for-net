// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppContainers.Models
{
    public partial class ContainerAppAuthPlatform : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IsEnabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(IsEnabled.Value);
            }
            if (Optional.IsDefined(RuntimeVersion))
            {
                writer.WritePropertyName("runtimeVersion"u8);
                writer.WriteStringValue(RuntimeVersion);
            }
            writer.WriteEndObject();
        }

        internal static ContainerAppAuthPlatform DeserializeContainerAppAuthPlatform(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> enabled = default;
            Optional<string> runtimeVersion = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("runtimeVersion"u8))
                {
                    runtimeVersion = property.Value.GetString();
                    continue;
                }
            }
            return new ContainerAppAuthPlatform(Optional.ToNullable(enabled), runtimeVersion.Value);
        }
    }
}
