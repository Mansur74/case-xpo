﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using CaseAPI.Models.caseproj;
namespace CaseAPI.Models.caseproj
{
    public partial class caseprojUnitOfWork : UnitOfWork
    {
        public caseprojUnitOfWork() : base() { }
        public caseprojUnitOfWork(DevExpress.Xpo.Metadata.XPDictionary dictionary) : base(dictionary) { }
        public caseprojUnitOfWork(IDataLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
        public caseprojUnitOfWork(IObjectLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static class caseprojXpoServiceCollectionExtensions
    {
        public static IServiceCollection AddcaseprojAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddcaseprojAsXpoDefaultSession(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddcaseprojUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<caseprojUnitOfWork>(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddcaseprojXpoDefaultDataLayer(this IServiceCollection serviceCollection, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, customDataLayerOptionsBuilder);
        }
        public static IServiceCollection AddcaseprojAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, o => { o.UseConnectionStringForcaseproj(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddcaseprojAsXpoDefaultSession(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, o => { o.UseConnectionStringForcaseproj(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddcaseprojUnitOfWork(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<caseprojUnitOfWork>(useDataLayerAsSingletone, o => { o.UseConnectionStringForcaseproj(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddcaseprojXpoDefaultDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, o => { o.UseConnectionStringForcaseproj(configuration); optionsBuilder(o); });
        }
        public static DataLayerOptionsBuilder UseConnectionStringForcaseproj(this DataLayerOptionsBuilder options, IConfiguration configuration)
        {
            return options.UseConnectionString(configuration.GetConnectionString(ConnectionHelper.ConnectionStringName));
        }
        static Action<DataLayerOptionsBuilder> CreateDataLayerOptionsBuilder(Action<DataLayerOptionsBuilder> injectCustomDataLayerOptionsBuilder)
        {
            return (options) =>
            {
                options
                .UseEntityTypes(ConnectionHelper.GetPersistentTypes());
                if (injectCustomDataLayerOptionsBuilder != null)
                {
                    injectCustomDataLayerOptionsBuilder(options);
                }
            };
        }
    }
}