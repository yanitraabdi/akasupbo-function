using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Interfaces
{
    public interface IContainerBuilder
    {
        IContainerBuilder RegisterModule(IModule dmodule = null);

        IServiceProvider Build();
    }
}
