using System;
using Microsoft.Extensions.DependencyInjection;
namespace IOC概念
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();//创建服务集合
            services.AddTransient<TestService1>(); //添加一个瞬时服务
            using (ServiceProvider sp = services.BuildServiceProvider()) //ServiceProvider=服务定位器
            {
                TestService1 t= sp.GetService<TestService1>();
                t.Name = "lilei";
                t.SayHi();
            }

            
        }
    }

    public interface ITestService
    {
        public string Name { get; set; }
        public void SayHi();
    }

    public class TestService1 : ITestService
    {
        public string Name { get; set; }

        public void SayHi()
        {
            Console.WriteLine(Name+ "TesetService1");
        }
    }
    public class TestService2 : ITestService
    {
        public string Name { get; set; }

        public void SayHi()
        {
            Console.WriteLine(Name + "TesetService2");
        }
    }
}
