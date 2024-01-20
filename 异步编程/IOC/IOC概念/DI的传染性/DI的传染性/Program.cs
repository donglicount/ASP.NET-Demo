using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;

namespace DI的传染性
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<Controller>();
            services.AddScoped<ILog,LogImpl>();
            services.AddScoped<IStorage,StorageImpl>();
            //services.AddScoped<IConfig,ConfigImpl>();
            services.AddScoped<IConfig,DBConfigImpl>();
            using (var sp=services.BuildServiceProvider())
            {
                var c= sp.GetRequiredService<Controller>();
                c.Test();
                Console.Read();
            }
        }
    }

    class Controller
    {
        private ILog log;
        private IStorage storage;

        public Controller(ILog log, IStorage storage)
        {
            this.log = log;
            this.storage = storage;
        }

        public void Test()
        {
            this.log.Log("开始上传");
            this.storage.Save("sssss","1.txt");
            this.log.Log("上传完毕");
        }
    }

    interface ILog
    {
        public void Log(string msg);
    }

    class LogImpl:ILog
    {
        public void Log(string msg)
        {
            Console.WriteLine($"日志:{msg}");
        }
    }

    interface IConfig
    {
        public string GetValue(string nane);
    }

    class ConfigImpl:IConfig
    {
        public string GetValue(string name)
        {
            return "读取配置";
        }
    }

    interface IStorage
    {
        public void Save(string content, string name);
    }

    class StorageImpl : IStorage
    {
        private readonly IConfig config;

        public StorageImpl(IConfig config)
        {
            this.config = config;
        }
        public void Save(string content,string name)
        {
            string server = config.GetValue("server");
            Console.WriteLine($"向服务器{server}的文件为{name}上传");
        }
    }

  

    class DBConfigImpl : IConfig
    {
        public string GetValue(string config)
        {
            Console.WriteLine("从数据库读取配置");

            return "从数据库读取配置";
        }
    }

}
