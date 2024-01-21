using System;
using System.Net.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace 配置系统入门
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<TestController>();
            services.AddScoped<Test2>();
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("config.json",optional:true,reloadOnChange:true);
            IConfigurationRoot configurationRoot= configurationBuilder.Build();

            services.AddOptions()
                .Configure<Config>(e => configurationRoot.Bind(e))
                .Configure<Proxy>(e=>configurationRoot.GetSection("proxy").Bind(e));
            services.AddScoped<TestController>();
            
            using (var sp = services.BuildServiceProvider())
            {
                while (true)
                {
                    using (var scope = sp.CreateScope())
                    {
                        var c = scope.ServiceProvider.GetRequiredService<TestController>();
                        c.Test();
                        var c2 = scope.ServiceProvider.GetRequiredService<Test2>();
                        c2.Test();
                    }
                    Console.WriteLine("点击任意键继续用");
                    Console.ReadKey();
                }
                
            }

            //string name = configurationRoot["name"];
            //Console.WriteLine($"name={name}");
            ////string address = configurationRoot.GetSection("proxy:address").Value;
            //Proxy proxy = configurationRoot.GetSection("proxy").Get<Proxy>();
            //var address = proxy.Address;
            //var Port = proxy.Port;
            //Console.WriteLine($"address={address},port={Port}");


        }


        public class Config
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Proxy Proxy { get; set; }
        }
        public class Proxy
        {
            public string Address { get; set; }
            public int Port { get; set; }
        }  
    }
}
