namespace D2
{
    partial class frmAccountCreate
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
            btnCancel = new Button();
            btnCreateD2RProfile = new Button();
            label1 = new Label();
            label2 = new Label();
            txtEmailAddress = new TextBox();
            txtPassword = new TextBox();
            btnShowHidePassword = new Button();
            label3 = new Label();
            txtMod = new TextBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(578, 348);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(169, 52);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreateD2RProfile
            // 
            btnCreateD2RProfile.Location = new Point(383, 348);
            btnCreateD2RProfile.Name = "btnCreateD2RProfile";
            btnCreateD2RProfile.Size = new Size(169, 52);
            btnCreateD2RProfile.TabIndex = 4;
            btnCreateD2RProfile.Text = "确定";
            btnCreateD2RProfile.UseVisualStyleBackColor = true;
            btnCreateD2RProfile.Click += btnCreateD2RProfile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 80);
            label1.Name = "label1";
            label1.Size = new Size(69, 35);
            label1.TabIndex = 2;
            label1.Text = "账号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 174);
            label2.Name = "label2";
            label2.Size = new Size(69, 35);
            label2.TabIndex = 3;
            label2.Text = "密码";
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmailAddress.Location = new Point(152, 70);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(595, 49);
            txtEmailAddress.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(152, 164);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(420, 49);
            txtPassword.TabIndex = 1;
            // 
            // btnShowHidePassword
            // 
            btnShowHidePassword.Location = new Point(578, 161);
            btnShowHidePassword.Name = "btnShowHidePassword";
            btnShowHidePassword.Size = new Size(169, 52);
            btnShowHidePassword.TabIndex = 2;
            btnShowHidePassword.Text = "显示";
            btnShowHidePassword.UseVisualStyleBackColor = true;
            btnShowHidePassword.Click += btnShowHidePassword_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 269);
            label3.Name = "label3";
            label3.Size = new Size(75, 35);
            label3.TabIndex = 7;
            label3.Text = "Mod";
            // 
            // txtMod
            // 
            txtMod.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtMod.Location = new Point(152, 259);
            txtMod.Name = "txtMod";
            txtMod.Size = new Size(595, 49);
            txtMod.TabIndex = 3;
            // 
            // frmAccountCreate
            // 
            AutoScaleDimensions = new SizeF(16F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(819, 440);
            Controls.Add(txtMod);
            Controls.Add(label3);
            Controls.Add(btnShowHidePassword);
            Controls.Add(txtPassword);
            Controls.Add(txtEmailAddress);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCreateD2RProfile);
            Controls.Add(btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAccountCreate";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "添加账号";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnCreateD2RProfile;
        private Label label1;
        private Label label2;
        private TextBox txtEmailAddress;
        private TextBox txtPassword;
        private Button btnShowHidePassword;
        private Label label3;
        private TextBox txtMod;
    }
}