using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using LogServices;
using Microsoft.Extensions.DependencyInjection;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleLogExtensions
    {
        //扩展方法
        public static void AddConsoleLog(this IServiceCollection services)
        {
            services.AddScoped<ILogProvider,ConsoleLogProvider>();
        }
    }
}
