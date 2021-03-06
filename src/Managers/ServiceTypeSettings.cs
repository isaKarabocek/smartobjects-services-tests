﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace SourceCode.SmartObjects.Services.Tests.Managers
{
    [ExcludeFromCodeCoverage]
    public abstract class ServiceTypeSettings
    {
        public virtual bool AlwaysUseDefaults
        {
            get
            {
                return false;
            }
        }

        public abstract string ClassName { get; }

        public abstract string DefaultDisplayName { get; }

        public abstract Guid DefaultGuid { get; }

        public abstract string DefaultName { get; }
    }
}