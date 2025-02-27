// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class ScriptAction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("uri"u8);
            writer.WriteStringValue(Uri.AbsoluteUri);
            writer.WritePropertyName("roles"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Roles);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(Roles.ToString()).RootElement);
#endif
            if (Optional.IsDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
                writer.WriteStringValue(Parameters);
            }
            writer.WriteEndObject();
        }

        internal static ScriptAction DeserializeScriptAction(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Uri uri = default;
            BinaryData roles = default;
            Optional<string> parameters = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("uri"u8))
                {
                    uri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("roles"u8))
                {
                    roles = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    parameters = property.Value.GetString();
                    continue;
                }
            }
            return new ScriptAction(name, uri, roles, parameters.Value);
        }
    }
}
