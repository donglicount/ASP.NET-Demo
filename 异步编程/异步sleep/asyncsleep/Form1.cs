using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncsleep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient http=new HttpClient())
            {
                string s=await http.GetStringAsync("http://www.youzack.com");
                textBox1.Text = s;
                await Task.Delay(3000);
                string s2=await http.GetStringAsync("http://www.baidu.com");
                textBox1.Text = s2;
            }
        }
    }
}
