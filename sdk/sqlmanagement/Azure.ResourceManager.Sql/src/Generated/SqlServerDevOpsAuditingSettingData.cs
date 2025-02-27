// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing the SqlServerDevOpsAuditingSetting data model.
    /// A server DevOps auditing settings.
    /// </summary>
    public partial class SqlServerDevOpsAuditingSettingData : ResourceData
    {
        /// <summary> Initializes a new instance of SqlServerDevOpsAuditingSettingData. </summary>
        public SqlServerDevOpsAuditingSettingData()
        {
        }

        /// <summary> Initializes a new instance of SqlServerDevOpsAuditingSettingData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isAzureMonitorTargetEnabled">
        /// Specifies whether DevOps audit events are sent to Azure Monitor. 
        /// In order to send the events to Azure Monitor, specify &apos;State&apos; as &apos;Enabled&apos; and &apos;IsAzureMonitorTargetEnabled&apos; as true.
        /// 
        /// When using REST API to configure DevOps audit, Diagnostic Settings with &apos;DevOpsOperationsAudit&apos; diagnostic logs category on the master database should be also created.
        /// 
        /// Diagnostic Settings URI format:
        /// PUT https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Sql/servers/{serverName}/databases/master/providers/microsoft.insights/diagnosticSettings/{settingsName}?api-version=2017-05-01-preview
        /// 
        /// For more information, see [Diagnostic Settings REST API](https://go.microsoft.com/fwlink/?linkid=2033207)
        /// or [Diagnostic Settings PowerShell](https://go.microsoft.com/fwlink/?linkid=2033043)
        /// 
        /// </param>
        /// <param name="isManagedIdentityInUse"> Specifies whether Managed Identity is used to access blob storage. </param>
        /// <param name="state"> Specifies the state of the audit. If state is Enabled, storageEndpoint or isAzureMonitorTargetEnabled are required. </param>
        /// <param name="storageEndpoint"> Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). If state is Enabled, storageEndpoint or isAzureMonitorTargetEnabled is required. </param>
        /// <param name="storageAccountAccessKey">
        /// Specifies the identifier key of the auditing storage account. 
        /// If state is Enabled and storageEndpoint is specified, not specifying the storageAccountAccessKey will use SQL server system-assigned managed identity to access the storage.
        /// Prerequisites for using managed identity authentication:
        /// 1. Assign SQL Server a system-assigned managed identity in Azure Active Directory (AAD).
        /// 2. Grant SQL Server identity access to the storage account by adding &apos;Storage Blob Data Contributor&apos; RBAC role to the server identity.
        /// For more information, see [Auditing to storage using Managed Identity authentication](https://go.microsoft.com/fwlink/?linkid=2114355)
        /// </param>
        /// <param name="storageAccountSubscriptionId"> Specifies the blob storage subscription Id. </param>
        internal SqlServerDevOpsAuditingSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? isAzureMonitorTargetEnabled, bool? isManagedIdentityInUse, BlobAuditingPolicyState? state, string storageEndpoint, string storageAccountAccessKey, Guid? storageAccountSubscriptionId) : base(id, name, resourceType, systemData)
        {
            IsAzureMonitorTargetEnabled = isAzureMonitorTargetEnabled;
            IsManagedIdentityInUse = isManagedIdentityInUse;
            State = state;
            StorageEndpoint = storageEndpoint;
            StorageAccountAccessKey = storageAccountAccessKey;
            StorageAccountSubscriptionId = storageAccountSubscriptionId;
        }

        /// <summary>
        /// Specifies whether DevOps audit events are sent to Azure Monitor. 
        /// In order to send the events to Azure Monitor, specify &apos;State&apos; as &apos;Enabled&apos; and &apos;IsAzureMonitorTargetEnabled&apos; as true.
        /// 
        /// When using REST API to configure DevOps audit, Diagnostic Settings with &apos;DevOpsOperationsAudit&apos; diagnostic logs category on the master database should be also created.
        /// 
        /// Diagnostic Settings URI format:
        /// PUT https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Sql/servers/{serverName}/databases/master/providers/microsoft.insights/diagnosticSettings/{settingsName}?api-version=2017-05-01-preview
        /// 
        /// For more information, see [Diagnostic Settings REST API](https://go.microsoft.com/fwlink/?linkid=2033207)
        /// or [Diagnostic Settings PowerShell](https://go.microsoft.com/fwlink/?linkid=2033043)
        /// 
        /// </summary>
        public bool? IsAzureMonitorTargetEnabled { get; set; }
        /// <summary> Specifies whether Managed Identity is used to access blob storage. </summary>
        public bool? IsManagedIdentityInUse { get; set; }
        /// <summary> Specifies the state of the audit. If state is Enabled, storageEndpoint or isAzureMonitorTargetEnabled are required. </summary>
        public BlobAuditingPolicyState? State { get; set; }
        /// <summary> Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). If state is Enabled, storageEndpoint or isAzureMonitorTargetEnabled is required. </summary>
        public string StorageEndpoint { get; set; }
        /// <summary>
        /// Specifies the identifier key of the auditing storage account. 
        /// If state is Enabled and storageEndpoint is specified, not specifying the storageAccountAccessKey will use SQL server system-assigned managed identity to access the storage.
        /// Prerequisites for using managed identity authentication:
        /// 1. Assign SQL Server a system-assigned managed identity in Azure Active Directory (AAD).
        /// 2. Grant SQL Server identity access to the storage account by adding &apos;Storage Blob Data Contributor&apos; RBAC role to the server identity.
        /// For more information, see [Auditing to storage using Managed Identity authentication](https://go.microsoft.com/fwlink/?linkid=2114355)
        /// </summary>
        public string StorageAccountAccessKey { get; set; }
        /// <summary> Specifies the blob storage subscription Id. </summary>
        public Guid? StorageAccountSubscriptionId { get; set; }
    }
}
