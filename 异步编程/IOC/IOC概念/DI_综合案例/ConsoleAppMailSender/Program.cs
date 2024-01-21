using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppMailSender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddScoped<IConfigSevrvice, EnvVarConfigService>();
            //services.AddScoped(typeof(IConfigSevrvice),s=> new IniFileConfigService{FilePath=$"D:\\杨中科ASP.NET\\异步编程\\IOC\\IOC概念\\DI_综合案例\\ConsoleAppMailSender\\Mail.ini"});
            services.AddScoped<IConfigSevrvice, EnvVarConfigService>();
            services.AddIniFileConfig($"D:\\杨中科ASP.NET\\异步编程\\IOC\\IOC概念\\DI_综合案例\\ConsoleAppMailSender\\Mail.ini");
            services.AddLayerConfig();
            services.AddScoped<IMailService, MailService>();
            //services.AddScoped<ILogProvider, ConsoleLogProvider>();
            services.AddConsoleLog();
            using (var sp=services.BuildServiceProvider())
            {
                var mailService = sp.GetRequiredService<IMailService>();
                mailService.Send("Hello","dl@qq.com","你好");
            }

            Console.Read();
        }
    }
}
