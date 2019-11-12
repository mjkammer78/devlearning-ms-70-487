//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using DatabaseFirst.Models;
using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;

namespace NorthwindWeb
{
    public class NorthwindCategories : EntityFrameworkDataService<NorthwindEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;

            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);

            config.UseVerboseErrors = true;
        }

        protected override void HandleException(HandleExceptionArgs args)
        {
            Console.Out.WriteLine(args.Exception);
        }
    }
}
