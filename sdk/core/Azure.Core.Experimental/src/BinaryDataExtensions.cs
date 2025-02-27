﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Extensions to BinaryData.
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data)
        {
            return new DynamicJson(MutableJsonDocument.Parse(data).RootElement, new DynamicJsonOptions());
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data, DynamicJsonNameMapping propertyNameCasing)
        {
            return new DynamicJson(MutableJsonDocument.Parse(data).RootElement, new DynamicJsonOptions() {  PropertyNameCasing = propertyNameCasing });
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data, DynamicJsonOptions options)
        {
            return new DynamicJson(MutableJsonDocument.Parse(data).RootElement, options);
        }
    }
}
