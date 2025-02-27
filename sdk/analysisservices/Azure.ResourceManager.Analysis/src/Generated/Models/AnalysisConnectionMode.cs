// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Analysis.Models
{
    /// <summary> How the read-write server&apos;s participation in the query pool is controlled.&lt;br/&gt;It can have the following values: &lt;ul&gt;&lt;li&gt;readOnly - indicates that the read-write server is intended not to participate in query operations&lt;/li&gt;&lt;li&gt;all - indicates that the read-write server can participate in query operations&lt;/li&gt;&lt;/ul&gt;Specifying readOnly when capacity is 1 results in error. </summary>
    public enum AnalysisConnectionMode
    {
        /// <summary> All. </summary>
        All,
        /// <summary> ReadOnly. </summary>
        ReadOnly
    }
}
