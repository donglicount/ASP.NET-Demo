using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ConfigServices;
using LogServices;

namespace MailServices
{
    public class MailService : IMailService
    {
        private readonly ILogProvider log;
        private readonly IConfigSevrvice config;

        public MailService(ILogProvider log, IConfigSevrvice config)
        {
            this.log = log;
            this.config = config;
        }
        public void Send(string title, string to, string content)
        {
            this.log.LogInfo("准备发送邮件");
            string smtpServer= this.config.GetValu("SmtpServer");
            string userName = this.config.GetValu("UserName");
            string passWord = this.config.GetValu("PassWord");
            Console.WriteLine($"邮件服务器地址：服务器{smtpServer},用户名{userName},密码{passWord}");
            Console.WriteLine($"发送邮件：标题{title}给{to}，内容：{content}");
            this.log.LogInfo("邮件发送完成");
        }
    }
}
