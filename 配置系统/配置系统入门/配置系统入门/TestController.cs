using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 配置系统入门
{
    public class TestController
    {
        private readonly IOptionsSnapshot<Program.Config> optConfig;

        public TestController(IOptionsSnapshot<Program.Config> optConfig)
        {
            this.optConfig = optConfig;
        }

        public void Test()
        {
            Console.WriteLine(optConfig.Value.Age);
            Console.WriteLine("---------------------");
            Console.WriteLine(optConfig.Value.Age);

        }
    }
}
