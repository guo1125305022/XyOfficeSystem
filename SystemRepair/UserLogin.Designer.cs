namespace SystemRepair
{
    partial class UserLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_userName = new System.Windows.Forms.TextBox();
            this.Tb_user_pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // Tb_userName
            // 
            this.Tb_userName.Location = new System.Drawing.Point(188, 126);
            this.Tb_userName.Name = "Tb_userName";
            this.Tb_userName.Size = new System.Drawing.Size(152, 21);
            this.Tb_userName.TabIndex = 1;
            // 
            // Tb_user_pwd
            // 
            this.Tb_user_pwd.Location = new System.Drawing.Point(188, 168);
            this.Tb_user_pwd.Name = "Tb_user_pwd";
            this.Tb_user_pwd.Size = new System.Drawing.Size(152, 21);
            this.Tb_user_pwd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            // 
            // Btn_login
            // 
            this.Btn_login.Location = new System.Drawing.Point(131, 220);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(209, 23);
            this.Btn_login.TabIndex = 4;
            this.Btn_login.Text = "登陆";
            this.Btn_login.UseVisualStyleBackColor = true;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 291);
            this.Controls.Add(this.Btn_login);
            this.Controls.Add(this.Tb_user_pwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tb_userName);
            this.Controls.Add(this.label1);
            this.Name = "UserLogin";
            this.Text = "用户登陆";
            this.Load += new System.EventHandler(this.UserLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_userName;
        private System.Windows.Forms.TextBox Tb_user_pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_login;
    }
}