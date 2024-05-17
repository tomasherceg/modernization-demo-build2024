using System;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using Modernization.BackendClient;

namespace Modernization.InPlace
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddWebFormsAdapters();

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            // register routes   
            config.RouteTable.Add("ProductDetail", "products/{id}", "Views/ProductDetail.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
        }
		
		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            
            options.Services.AddScoped<ApiClient>(_ => Global.GetApiClient());
        }
    }
}
