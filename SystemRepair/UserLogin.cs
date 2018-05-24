using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemRepair
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb_userName.Text)) {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(Tb_user_pwd.Text)) {
                MessageBox.Show("用户密码不能为空");
                return;
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
