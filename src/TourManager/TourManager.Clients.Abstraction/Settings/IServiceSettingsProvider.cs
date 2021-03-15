using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Clients.Abstraction.Settings
{
    public interface IServiceSettingsProvider
    {
        string ComposeActivityServiceUrl();

        string ComposePropertyServiceUrl();
    }
}
