// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Batch.Models
{
    public partial class BatchCertificateReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            if (Optional.IsDefined(StoreLocation))
            {
                writer.WritePropertyName("storeLocation"u8);
                writer.WriteStringValue(StoreLocation.Value.ToSerialString());
            }
            if (Optional.IsDefined(StoreName))
            {
                writer.WritePropertyName("storeName"u8);
                writer.WriteStringValue(StoreName);
            }
            if (Optional.IsCollectionDefined(Visibility))
            {
                writer.WritePropertyName("visibility"u8);
                writer.WriteStartArray();
                foreach (var item in Visibility)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static BatchCertificateReference DeserializeBatchCertificateReference(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            Optional<BatchCertificateStoreLocation> storeLocation = default;
            Optional<string> storeName = default;
            Optional<IList<BatchCertificateVisibility>> visibility = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("storeLocation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    storeLocation = property.Value.GetString().ToBatchCertificateStoreLocation();
                    continue;
                }
                if (property.NameEquals("storeName"u8))
                {
                    storeName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("visibility"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<BatchCertificateVisibility> array = new List<BatchCertificateVisibility>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToBatchCertificateVisibility());
                    }
                    visibility = array;
                    continue;
                }
            }
            return new BatchCertificateReference(id, Optional.ToNullable(storeLocation), storeName.Value, Optional.ToList(visibility));
        }
    }
}
