﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Applicant.WebApp.Factory
{
    public static class ServiceSetupExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection service, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IServiceSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IServiceSetup>().ToList();
            installers.ForEach(installer => installer.InstallService(service, configuration));
        }
    }
}
