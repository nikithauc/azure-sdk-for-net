// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Logic
{
    public partial class LogicWorkflowRunActionRepetitionDefinitionData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startTime"u8);
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (Optional.IsDefined(EndOn))
            {
                writer.WritePropertyName("endTime"u8);
                writer.WriteStringValue(EndOn.Value, "O");
            }
            if (Optional.IsDefined(Correlation))
            {
                writer.WritePropertyName("correlation"u8);
                writer.WriteObjectValue(Correlation);
            }
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Optional.IsDefined(Code))
            {
                writer.WritePropertyName("code"u8);
                writer.WriteStringValue(Code);
            }
            if (Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Error);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Error.ToString()).RootElement);
#endif
            }
            if (Optional.IsCollectionDefined(RetryHistory))
            {
                writer.WritePropertyName("retryHistory"u8);
                writer.WriteStartArray();
                foreach (var item in RetryHistory)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(IterationCount))
            {
                writer.WritePropertyName("iterationCount"u8);
                writer.WriteNumberValue(IterationCount.Value);
            }
            if (Optional.IsCollectionDefined(RepetitionIndexes))
            {
                writer.WritePropertyName("repetitionIndexes"u8);
                writer.WriteStartArray();
                foreach (var item in RepetitionIndexes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static LogicWorkflowRunActionRepetitionDefinitionData DeserializeLogicWorkflowRunActionRepetitionDefinitionData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            Optional<LogicWorkflowRunActionCorrelation> correlation = default;
            Optional<LogicWorkflowStatus> status = default;
            Optional<string> code = default;
            Optional<BinaryData> error = default;
            Optional<Guid> trackingId = default;
            Optional<BinaryData> inputs = default;
            Optional<LogicContentLink> inputsLink = default;
            Optional<BinaryData> outputs = default;
            Optional<LogicContentLink> outputsLink = default;
            Optional<BinaryData> trackedProperties = default;
            Optional<IList<LogicWorkRetryHistory>> retryHistory = default;
            Optional<int> iterationCount = default;
            Optional<IList<LogicWorkflowRepetitionIndex>> repetitionIndexes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("startTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            startTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("endTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            endTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("correlation"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            correlation = LogicWorkflowRunActionCorrelation.DeserializeLogicWorkflowRunActionCorrelation(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("status"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            status = new LogicWorkflowStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("code"u8))
                        {
                            code = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("error"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            error = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("trackingId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            trackingId = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("inputs"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            inputs = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("inputsLink"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            inputsLink = LogicContentLink.DeserializeLogicContentLink(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("outputs"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            outputs = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("outputsLink"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            outputsLink = LogicContentLink.DeserializeLogicContentLink(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("trackedProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            trackedProperties = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("retryHistory"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<LogicWorkRetryHistory> array = new List<LogicWorkRetryHistory>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(LogicWorkRetryHistory.DeserializeLogicWorkRetryHistory(item));
                            }
                            retryHistory = array;
                            continue;
                        }
                        if (property0.NameEquals("iterationCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            iterationCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("repetitionIndexes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<LogicWorkflowRepetitionIndex> array = new List<LogicWorkflowRepetitionIndex>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(LogicWorkflowRepetitionIndex.DeserializeLogicWorkflowRepetitionIndex(item));
                            }
                            repetitionIndexes = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new LogicWorkflowRunActionRepetitionDefinitionData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, Optional.ToNullable(startTime), Optional.ToNullable(endTime), correlation.Value, Optional.ToNullable(status), code.Value, error.Value, Optional.ToNullable(trackingId), inputs.Value, inputsLink.Value, outputs.Value, outputsLink.Value, trackedProperties.Value, Optional.ToList(retryHistory), Optional.ToNullable(iterationCount), Optional.ToList(repetitionIndexes));
        }
    }
}
