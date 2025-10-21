using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventorSignatureAddIn
{
    /// <summary>
    /// 用户认证窗体
    /// </summary>
    public partial class AuthenticationForm : Form
    {
        private TextBox txt用户名;
        private TextBox txt密码;
        private Button btn确定;
        private Button btn取消;
        private Label lbl用户名;
        private Label lbl密码;
        private Label lbl标题;

        public string Username => txt用户名.Text;
        public string Password => txt密码.Text;

        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 窗体设置
            this.Text = "电子签名 - 用户认证";
            this.Size = new Size(350, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // 标题标签
            lbl标题 = new Label
            {
                Text = "请输入您的凭据",
                Location = new Point(20, 20),
                Size = new Size(300, 20),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            // 用户名标签
            lbl用户名 = new Label
            {
                Text = "用户名:",
                Location = new Point(20, 60),
                Size = new Size(80, 20)
            };

            // 用户名文本框
            txt用户名 = new TextBox
            {
                Location = new Point(100, 60),
                Size = new Size(200, 20),
                TabIndex = 0
            };

            // 密码标签
            lbl密码 = new Label
            {
                Text = "密码:",
                Location = new Point(20, 100),
                Size = new Size(80, 20)
            };

            // 密码文本框
            txt密码 = new TextBox
            {
                Location = new Point(100, 100),
                Size = new Size(200, 20),
                PasswordChar = '*',
                TabIndex = 1
            };

            // 确定按钮
            btn确定 = new Button
            {
                Text = "确定",
                Location = new Point(150, 150),
                Size = new Size(75, 30),
                DialogResult = DialogResult.OK,
                TabIndex = 2
            };

            // 取消按钮
            btn取消 = new Button
            {
                Text = "取消",
                Location = new Point(235, 150),
                Size = new Size(75, 30),
                DialogResult = DialogResult.Cancel,
                TabIndex = 3
            };

            // 将控件添加到窗体
            this.Controls.AddRange(new Control[] {
                lbl标题, lbl用户名, txt用户名, 
                lbl密码, txt密码, btn确定, btn取消
            });

            // 设置接受和取消按钮
            this.AcceptButton = btn确定;
            this.CancelButton = btn取消;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txt用户名.Focus(); // 窗体加载时焦点设置在用户名文本框
        }
    }
}
