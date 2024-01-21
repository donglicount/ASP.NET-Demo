using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace 配置系统入门
{
    public class Test2
    {
        private readonly IOptionsSnapshot<Program.Proxy> optProxy;

        public Test2(IOptionsSnapshot<Program.Proxy> optProxy)
        {
            this.optProxy=optProxy;
        }

        public void Test()
        {
            Console.WriteLine(optProxy.Value.Address);
        }
    }
}
