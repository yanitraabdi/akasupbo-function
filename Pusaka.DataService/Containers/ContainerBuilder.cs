using Microsoft.Extensions.DependencyInjection;
using Pusaka.DataService.Interfaces;
using Pusaka.DataService.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Containers
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly IServiceCollection _services;

        public ContainerBuilder()
        {
            this._services = new ServiceCollection();
        }

        public IContainerBuilder RegisterModule(IModule module = null)
        {
            if (module == null)
            {
                module = new AppModule();
            }

            module.Load(this._services);

            return this;
        }

        public IServiceProvider Build()
        {
            var provider = this._services.BuildServiceProvider();

            return provider;
        }
    }
}
