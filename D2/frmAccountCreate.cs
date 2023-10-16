using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2
{
    public delegate void frmAccountCreateOKEventHandler(string profilename, string email, string password, string mod);
    public delegate void frmAccountCreateCancelEventHandler();
    public partial class frmAccountCreate : Form
    {

        public event frmAccountCreateOKEventHandler OnCreateAccount;
        public event frmAccountCreateCancelEventHandler OnCancel;
        public frmAccountCreate()
        {
            InitializeComponent();
        }
        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar != '*')
            {
                txtPassword.PasswordChar = '*';
                btnShowHidePassword.Text = "显示";
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                btnShowHidePassword.Text = "隐藏";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnCancel != null)
                {
                    OnCancel();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateD2RProfile_Click(object sender, EventArgs e)
        {
            string ProfileName = txtEmailAddress.Text.Trim();
            string EmailAddress = txtEmailAddress.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string mod = txtMod.Text.Trim();

            string fullpathname = Application.StartupPath + "\\" + ProfileName + ".profile";
            if (File.Exists(fullpathname))
            {
                MessageBox.Show(this, "账号已存在", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEmailAddress.TextLength < 5 || txtEmailAddress.TextLength > 321)
            {
                MessageBox.Show(this, "账号格式不正确", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsValidEmail(txtEmailAddress.Text))
            {
                MessageBox.Show(this, "账号格式不正确", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.TextLength < 1 || txtPassword.TextLength > 100)
            {
                MessageBox.Show(this, "密码格式不正确", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //检查mod为-Mod开头不区分大小写
            mod = mod.ToLower();

            if (txtMod.TextLength > 0 && !mod.StartsWith("-mod"))
            {
                MessageBox.Show(this, "Mod格式不正确", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (OnCreateAccount != null)
            {
                OnCreateAccount(ProfileName, EmailAddress, Password, mod);
            }

            this.Close();
        }
    }
}
