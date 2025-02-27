// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class AutoscaleSettingsResourceInfo : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("maxThroughput"u8);
            writer.WriteNumberValue(MaxThroughput);
            if (Optional.IsDefined(AutoUpgradePolicy))
            {
                writer.WritePropertyName("autoUpgradePolicy"u8);
                writer.WriteObjectValue(AutoUpgradePolicy);
            }
            writer.WriteEndObject();
        }

        internal static AutoscaleSettingsResourceInfo DeserializeAutoscaleSettingsResourceInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int maxThroughput = default;
            Optional<AutoUpgradePolicyResourceInfo> autoUpgradePolicy = default;
            Optional<int> targetMaxThroughput = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxThroughput"u8))
                {
                    maxThroughput = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("autoUpgradePolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    autoUpgradePolicy = AutoUpgradePolicyResourceInfo.DeserializeAutoUpgradePolicyResourceInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("targetMaxThroughput"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    targetMaxThroughput = property.Value.GetInt32();
                    continue;
                }
            }
            return new AutoscaleSettingsResourceInfo(maxThroughput, autoUpgradePolicy.Value, Optional.ToNullable(targetMaxThroughput));
        }
    }
}
