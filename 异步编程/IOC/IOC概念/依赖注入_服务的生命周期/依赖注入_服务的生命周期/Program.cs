using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace 依赖注入_服务的生命周期
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();//创建服务集合
            services.AddScoped<ITestService, TestService1>();//服务类型使用接口，实现类型使用类
            services.AddScoped<ITestService, TestService2>();//服务类型使用接口，实现类型使用类
            //services.AddScoped(typeof(ITestService), typeof(TestService1));//与上一句泛型方法效果一致
            using (ServiceProvider sp=services.BuildServiceProvider())
            {
                //如果GetService找不到服务，则会返回null
                //ITestService ts1 = sp.GetService<ITestService>();
                //ITestService ts1= (ITestService)sp.GetService(typeof(ITestService));//这种写法需要强制转换
                //TestService1 ts1 = sp.GetRequiredService<TestService1>();//Required：必须的，找不到服务时会直接抛异常

                //ts1.Name = "Ton";
                //ts1.SayHi();
                //Console.WriteLine(ts1.GetType());

                IEnumerable<ITestService> tests = sp.GetServices<ITestService>();//获取多个服务
                foreach (var testService in tests)
                {
                    Console.WriteLine(testService.GetType());
                }
            }
        }



        //瞬时
        static void Main1(string[] args)
        {
            ServiceCollection services = new ServiceCollection();//创建服务集合
            services.AddTransient<TestService1>(); //添加一个瞬时服务
            using (ServiceProvider sp = services.BuildServiceProvider()) //ServiceProvider=服务定位器
            {
                TestService1 t = sp.GetService<TestService1>();
                t.Name = "lilei";
                t.SayHi();

                TestService1 t1 = sp.GetService<TestService1>();
                t1.Name = "hanmeimei";
                t1.SayHi();
                t.SayHi();
                Console.WriteLine("t和t1是否是同一个对象？ " + object.ReferenceEquals(t, t1));
                //这里返回False,说明Transient每次获取时都会给一个新的对象
            }
        }
        //单例
        static void Main2(string[] args)
        {
            ServiceCollection services = new ServiceCollection();//创建服务集合
            services.AddSingleton<TestService1>(); //添加一个瞬时服务
            using (ServiceProvider sp = services.BuildServiceProvider()) //ServiceProvider=服务定位器
            {
                TestService1 t = sp.GetService<TestService1>();
                t.Name = "lilei";
                t.SayHi();

                TestService1 t1 = sp.GetService<TestService1>();
                t1.Name = "hanmeimei";
                t1.SayHi();
                t.SayHi();
                Console.WriteLine("t和t1是否是同一个对象？ " + object.ReferenceEquals(t, t1));
            }
        }

        //范围
        static void Main3(string[] args)
        {
            ServiceCollection services = new ServiceCollection();//创建服务集合
            services.AddScoped<TestService1>(); //添加一个瞬时服务
            using (ServiceProvider sp = services.BuildServiceProvider()) //ServiceProvider=服务定位器
            {
                TestService1 tt1;

                using (IServiceScope scope = sp.CreateScope())
                {
                    //在scope中获取scope相关的对象，scope.ServiceProvider而不是scope1.ServiceProvider
                    TestService1 t = scope.ServiceProvider.GetService<TestService1>();
                    t.Name = "lilei";
                    t.SayHi();

                    TestService1 t1 = scope.ServiceProvider.GetService<TestService1>();
                    t1.Name = "hanmeimei";
                    t1.SayHi();
                    t.SayHi();
                    Console.WriteLine("t和t1是否是同一个对象？ " + object.ReferenceEquals(t, t1));
                    //因为在同一个scope中所以是同一个对象，返回True

                    tt1 = t1;
                }

                using (IServiceScope scope2 = sp.CreateScope())
                {
                    //在scope中获取scope相关的对象，scope.ServiceProvider而不是scope1.ServiceProvider
                    TestService1 t = scope2.ServiceProvider.GetService<TestService1>();
                    t.Name = "lilei";
                    t.SayHi();

                    TestService1 t1 = scope2.ServiceProvider.GetService<TestService1>();
                    t1.Name = "hanmeimei";
                    t1.SayHi();
                    t.SayHi();
                    //因为在同一个scope中所以是同一个对象，返回True
                    Console.WriteLine("t和t1是否是同一个对象？ " + object.ReferenceEquals(t, t1));

                    //两个范围内的对象是不同的
                    Console.WriteLine("tt1和t1是否是同一个对象？ " + object.ReferenceEquals(tt1, t1));
                }

            }
        }
    }

    public interface ITestService
    {
        public string Name { get; set; }
        public void SayHi();
    }

    public class TestService1 : ITestService,IDisposable
    {
        public string Name { get; set; }

        public void Dispose()
        {
            Console.WriteLine("离开时Scope后Disposed");
        }

        public void SayHi()
        {
            Console.WriteLine(Name + "TesetService1");
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
