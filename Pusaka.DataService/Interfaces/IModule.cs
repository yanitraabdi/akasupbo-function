using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Interfaces
{
    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}
