using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigServices
{
    public static class LayerConfigExtensions
    {
        public static void AddLayerConfig(this IServiceCollection services)
        {
            services.AddScoped<IConfigReader, LayerConfigReader>();
        }
    }
}
