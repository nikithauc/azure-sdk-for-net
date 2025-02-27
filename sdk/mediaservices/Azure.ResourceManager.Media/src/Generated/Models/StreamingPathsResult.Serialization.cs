// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Media.Models
{
    public partial class StreamingPathsResult
    {
        internal static StreamingPathsResult DeserializeStreamingPathsResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<StreamingPath>> streamingPaths = default;
            Optional<IReadOnlyList<string>> downloadPaths = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("streamingPaths"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<StreamingPath> array = new List<StreamingPath>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StreamingPath.DeserializeStreamingPath(item));
                    }
                    streamingPaths = array;
                    continue;
                }
                if (property.NameEquals("downloadPaths"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    downloadPaths = array;
                    continue;
                }
            }
            return new StreamingPathsResult(Optional.ToList(streamingPaths), Optional.ToList(downloadPaths));
        }
    }
}
