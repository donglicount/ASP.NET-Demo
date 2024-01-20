using System;
using System.Collections.Generic;
using System.Text;
using ConfigServices;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IniFileConfigExtensions
    {
        public static void AddIniFileConfig(this IServiceCollection services, string fielpath)
        {
            services.AddScoped(typeof(IConfigSevrvice),s=> new IniFileConfigService { FilePath = fielpath });
        }
    }
}
