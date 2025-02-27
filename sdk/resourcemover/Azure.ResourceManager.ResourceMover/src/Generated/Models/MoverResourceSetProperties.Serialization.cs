// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    public partial class MoverResourceSetProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("sourceRegion"u8);
            writer.WriteStringValue(SourceRegion);
            writer.WritePropertyName("targetRegion"u8);
            writer.WriteStringValue(TargetRegion);
            writer.WriteEndObject();
        }

        internal static MoverResourceSetProperties DeserializeMoverResourceSetProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureLocation sourceRegion = default;
            AzureLocation targetRegion = default;
            Optional<MoverProvisioningState> provisioningState = default;
            Optional<MoveCollectionPropertiesErrors> errors = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceRegion"u8))
                {
                    sourceRegion = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("targetRegion"u8))
                {
                    targetRegion = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("provisioningState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    provisioningState = new MoverProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        errors = null;
                        continue;
                    }
                    errors = MoveCollectionPropertiesErrors.DeserializeMoveCollectionPropertiesErrors(property.Value);
                    continue;
                }
            }
            return new MoverResourceSetProperties(sourceRegion, targetRegion, Optional.ToNullable(provisioningState), errors.Value);
        }
    }
}
