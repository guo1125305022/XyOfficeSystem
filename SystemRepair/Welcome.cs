using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemBusiness.systemBase;

namespace SystemRepair
{
    public partial class Welcome : Form
    {
        private SystemCheckSelvice selvice;
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            
            selvice = new SystemCheckSelvice();
            selvice.OnCheckEndListener += Selvice_OnCheckEndListener; ;
            selvice.OnCheckExceptionListener += Selvice_OnCheckExceptionListener; ;
            selvice.OnCheckIngListener += Selvice_OnCheckIngListener; ;
            selvice.OnCheckInitListener += Selvice_OnCheckInitListener; ;
            selvice.OnCheckStartListener += Selvice_OnCheckStartListener; ;
            selvice.StartCheckSystem();
        }

        private void Selvice_OnCheckStartListener(object service, int count)
        {
            lb_check.Text = "系统检查开始";
            pb_fix.Maximum = count;
            
        }

        private void Selvice_OnCheckInitListener(object service)
        {
            lb_check.Text = "系统初始化中";
        }

        private void Selvice_OnCheckIngListener(object service, int count, int current)
        {
            lb_check.Text = "系统检测中 检查数量"+count+"当前数量："+current;
            pb_fix.Value = current;
            pb_fix.Update();
        }

        private void Selvice_OnCheckExceptionListener(object service, Exception e)
        {
            lb_check.Text = "系统检查异常" + e.Message;
            MessageBox.Show("系统检测异常：\n" + e.Message);
        }

        private void Selvice_OnCheckEndListener(object service)
        {
            lb_check.Text = "系统检查完成";
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
            //timer1.Enabled = false;
            //this.Hide();
            //UserLogin login = new UserLogin();
            //login.Show();
        }
    }
}
