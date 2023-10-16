namespace D2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnStartAccount = new Button();
            richTextBox1 = new RichTextBox();
            lstProfiles = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            button3 = new Button();
            btnRemoveAccount = new Button();
            optArgumentsWindowed = new CheckBox();
            optArgumentsNoSound = new CheckBox();
            optArgumentsLowQuality = new CheckBox();
            ddRealm = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            label1 = new Label();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartAccount
            // 
            btnStartAccount.Location = new Point(760, 564);
            btnStartAccount.Margin = new Padding(7, 6, 7, 6);
            btnStartAccount.Name = "btnStartAccount";
            btnStartAccount.Size = new Size(313, 113);
            btnStartAccount.TabIndex = 0;
            btnStartAccount.Text = "启动";
            btnStartAccount.UseVisualStyleBackColor = true;
            btnStartAccount.Visible = false;
            btnStartAccount.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(14, 54);
            richTextBox1.Margin = new Padding(7, 6, 7, 6);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1941, 322);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // lstProfiles
            // 
            lstProfiles.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lstProfiles.FullRowSelect = true;
            lstProfiles.Location = new Point(71, 58);
            lstProfiles.Margin = new Padding(7, 6, 7, 6);
            lstProfiles.MultiSelect = false;
            lstProfiles.Name = "lstProfiles";
            lstProfiles.Size = new Size(642, 619);
            lstProfiles.TabIndex = 3;
            lstProfiles.UseCompatibleStateImageBehavior = false;
            lstProfiles.View = View.Details;
            lstProfiles.SelectedIndexChanged += lstProfiles_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "账号";
            columnHeader1.Width = 440;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Mod";
            columnHeader2.Width = 180;
            // 
            // button3
            // 
            button3.Location = new Point(760, 58);
            button3.Margin = new Padding(7, 6, 7, 6);
            button3.Name = "button3";
            button3.Size = new Size(313, 68);
            button3.TabIndex = 4;
            button3.Text = "添加账号";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btnRemoveAccount
            // 
            btnRemoveAccount.Location = new Point(760, 161);
            btnRemoveAccount.Margin = new Padding(7, 6, 7, 6);
            btnRemoveAccount.Name = "btnRemoveAccount";
            btnRemoveAccount.Size = new Size(313, 68);
            btnRemoveAccount.TabIndex = 4;
            btnRemoveAccount.Text = "删除账号";
            btnRemoveAccount.UseVisualStyleBackColor = true;
            btnRemoveAccount.Visible = false;
            btnRemoveAccount.Click += button4_Click;
            // 
            // optArgumentsWindowed
            // 
            optArgumentsWindowed.AutoSize = true;
            optArgumentsWindowed.Checked = true;
            optArgumentsWindowed.CheckState = CheckState.Checked;
            optArgumentsWindowed.Location = new Point(760, 252);
            optArgumentsWindowed.Margin = new Padding(7, 6, 7, 6);
            optArgumentsWindowed.Name = "optArgumentsWindowed";
            optArgumentsWindowed.Size = new Size(101, 39);
            optArgumentsWindowed.TabIndex = 5;
            optArgumentsWindowed.Text = "窗口";
            optArgumentsWindowed.UseVisualStyleBackColor = true;
            // 
            // optArgumentsNoSound
            // 
            optArgumentsNoSound.AutoSize = true;
            optArgumentsNoSound.Checked = true;
            optArgumentsNoSound.CheckState = CheckState.Checked;
            optArgumentsNoSound.Location = new Point(760, 307);
            optArgumentsNoSound.Margin = new Padding(7, 6, 7, 6);
            optArgumentsNoSound.Name = "optArgumentsNoSound";
            optArgumentsNoSound.Size = new Size(101, 39);
            optArgumentsNoSound.TabIndex = 5;
            optArgumentsNoSound.Text = "静音";
            optArgumentsNoSound.UseVisualStyleBackColor = true;
            // 
            // optArgumentsLowQuality
            // 
            optArgumentsLowQuality.AutoSize = true;
            optArgumentsLowQuality.Checked = true;
            optArgumentsLowQuality.CheckState = CheckState.Checked;
            optArgumentsLowQuality.Location = new Point(760, 363);
            optArgumentsLowQuality.Margin = new Padding(7, 6, 7, 6);
            optArgumentsLowQuality.Name = "optArgumentsLowQuality";
            optArgumentsLowQuality.Size = new Size(128, 39);
            optArgumentsLowQuality.TabIndex = 5;
            optArgumentsLowQuality.Text = "低效果";
            optArgumentsLowQuality.UseVisualStyleBackColor = true;
            // 
            // ddRealm
            // 
            ddRealm.DropDownStyle = ComboBoxStyle.DropDownList;
            ddRealm.FormattingEnabled = true;
            ddRealm.Items.AddRange(new object[] { "美服", "欧服", "亚服" });
            ddRealm.Location = new Point(23, 45);
            ddRealm.Margin = new Padding(7, 6, 7, 6);
            ddRealm.Name = "ddRealm";
            ddRealm.Size = new Size(271, 43);
            ddRealm.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ddRealm);
            groupBox1.Location = new Point(760, 414);
            groupBox1.Margin = new Padding(7, 6, 7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 6, 7, 6);
            groupBox1.Size = new Size(313, 126);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务器";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(71, 724);
            groupBox2.Margin = new Padding(7, 6, 7, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 6, 7, 6);
            groupBox2.Size = new Size(1969, 388);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "日志";
            // 
            // button1
            // 
            button1.Location = new Point(1122, 564);
            button1.Name = "button1";
            button1.Size = new Size(313, 113);
            button1.TabIndex = 9;
            button1.Text = "杀进程";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(906, 434);
            label1.TabIndex = 11;
            label1.Text = "1.需要在运行目录下安装微软Handle.exe官方工具，并改名为handle.exe\r\n2.可以添加账号信息直接进行多开，或者只使用杀进程功能手动开战网然后杀进程\r\n3.目前使用账号信息直接登录多开时，亚服连接存在问题，无法连接战网，可以选择其他服，默认不选时美服。";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(1122, 58);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(918, 482);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "说明";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(16F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(2103, 1132);
            Controls.Add(groupBox3);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(optArgumentsLowQuality);
            Controls.Add(optArgumentsNoSound);
            Controls.Add(optArgumentsWindowed);
            Controls.Add(btnRemoveAccount);
            Controls.Add(button3);
            Controls.Add(lstProfiles);
            Controls.Add(btnStartAccount);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(7, 6, 7, 6);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "D2多开";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartAccount;
        private RichTextBox richTextBox1;
        private ListView lstProfiles;
        private Button button3;
        private Button btnRemoveAccount;
        private CheckBox optArgumentsWindowed;
        private CheckBox optArgumentsNoSound;
        private CheckBox optArgumentsLowQuality;
        private ComboBox ddRealm;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button button1;
        private Label label1;
        private GroupBox groupBox3;
    }
}