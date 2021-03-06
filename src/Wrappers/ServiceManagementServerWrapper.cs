﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.SmartObjects.Services.Management;
using SourceCode.SmartObjects.Services.Tests.Extensions;
using SourceCode.SmartObjects.Services.Tests.Interfaces;

namespace SourceCode.SmartObjects.Services.Tests.Wrappers
{
    internal class ServiceManagementServerWrapper : IBaseAPI
    {
        private readonly ServiceManagementServer _serviceManagementServer;

        [ExcludeFromCodeCoverage]
        public ServiceManagementServerWrapper(ServiceManagementServer serviceManagementServer)
        {
            serviceManagementServer.ThrowIfNull(nameof(serviceManagementServer));

            _serviceManagementServer = serviceManagementServer;
        }

        public ServiceManagementServerWrapper()
        {
        }

        [ExcludeFromCodeCoverage]
        public virtual BaseAPI BaseAPIServer
        {
            get
            {
                return _serviceManagementServer;
            }
        }

        public void DeleteServiceInstance(Guid serviceInstanceGuid)
        {
            if (!string.IsNullOrEmpty(this.GetServiceInstanceCompact(serviceInstanceGuid)))
            {
                this.DeleteServiceInstance(serviceInstanceGuid, false);
            }
        }

        [ExcludeFromCodeCoverage]
        internal virtual bool DeleteServiceInstance(Guid ServiceInstanceGuid, bool IgnoreDependancy)
        {
            return _serviceManagementServer.DeleteServiceInstance(ServiceInstanceGuid, IgnoreDependancy);
        }

        [ExcludeFromCodeCoverage]
        internal virtual bool DeleteServiceType(Guid ServiceTypeGuid, bool IgnoreDependancy)
        {
            return _serviceManagementServer.DeleteServiceType(ServiceTypeGuid, IgnoreDependancy);
        }

        [ExcludeFromCodeCoverage]
        internal virtual IDictionary<string, string> GetRegisterableServices()
        {
            return _serviceManagementServer.GetRegisterableServices();
        }

        [ExcludeFromCodeCoverage]
        internal virtual string GetServiceInstance(Guid ServiceInstanceGuid)
        {
            return _serviceManagementServer.GetServiceInstance(ServiceInstanceGuid);
        }

        [ExcludeFromCodeCoverage]
        internal virtual string GetServiceInstanceCompact(Guid ServiceInstanceGuid)
        {
            return _serviceManagementServer.GetServiceInstanceCompact(ServiceInstanceGuid);
        }

        [ExcludeFromCodeCoverage]
        internal virtual string GetServiceInstanceConfig(Guid ServiceTypeGuid)
        {
            return _serviceManagementServer.GetServiceInstanceConfig(ServiceTypeGuid);
        }

        [ExcludeFromCodeCoverage]
        internal virtual string GetServiceInstancesCompact(Guid ServiceTypeGuid)
        {
            return _serviceManagementServer.GetServiceInstancesCompact(ServiceTypeGuid);
        }

        [ExcludeFromCodeCoverage]
        internal virtual string GetServiceType(Guid ServiceTypeGuid)
        {
            return _serviceManagementServer.GetServiceType(ServiceTypeGuid);
        }

        [ExcludeFromCodeCoverage]
        internal virtual IEnumerable<ServiceTypeInfo> GetServiceTypes()
        {
            using (_serviceManagementServer.Connection)
            {
                var serviceTypesXml = _serviceManagementServer.GetServiceTypes();
                return ServiceTypeInfoList.Create(serviceTypesXml).ToArray();
            }
        }

        [ExcludeFromCodeCoverage]
        internal virtual bool RefreshServiceInstance(Guid ServiceInstanceGuid)
        {
            return _serviceManagementServer.RefreshServiceInstance(ServiceInstanceGuid);
        }

        [ExcludeFromCodeCoverage]
        internal virtual bool RefreshServiceInstance(Guid ServiceInstanceGuid, string ServiceInstanceConfig)
        {
            return _serviceManagementServer.RefreshServiceInstance(ServiceInstanceGuid, ServiceInstanceConfig);
        }

        [ExcludeFromCodeCoverage]
        internal virtual bool RegisterServiceInstance(Guid ServiceTypeGuid, Guid ServiceInstanceGuid, string SystemName, string DisplayName, string Description, string ConfigSettings)
        {
            return _serviceManagementServer.RegisterServiceInstance(ServiceTypeGuid, ServiceInstanceGuid, SystemName, DisplayName, Description, ConfigSettings);
        }

        [ExcludeFromCodeCoverage]
        internal virtual bool RegisterServiceType(Guid ServiceTypeGuid, string SystemName, string DisplayName, string Description, string Path, string Class)
        {
            return _serviceManagementServer.RegisterServiceType(ServiceTypeGuid, SystemName, DisplayName, Description, Path, Class);
        }
    }
}