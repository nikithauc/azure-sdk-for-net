// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Workloads.Models
{
    public partial class SapDiskConfiguration
    {
        internal static SapDiskConfiguration DeserializeSapDiskConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DiskVolumeConfiguration> recommendedConfiguration = default;
            Optional<IReadOnlyList<SupportedConfigurationsDiskDetails>> supportedConfigurations = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("recommendedConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    recommendedConfiguration = DiskVolumeConfiguration.DeserializeDiskVolumeConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("supportedConfigurations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SupportedConfigurationsDiskDetails> array = new List<SupportedConfigurationsDiskDetails>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SupportedConfigurationsDiskDetails.DeserializeSupportedConfigurationsDiskDetails(item));
                    }
                    supportedConfigurations = array;
                    continue;
                }
            }
            return new SapDiskConfiguration(recommendedConfiguration.Value, Optional.ToList(supportedConfigurations));
        }
    }
}
