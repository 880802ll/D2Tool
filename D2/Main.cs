using D2R_MULTILAUNCHER;
using System.Diagnostics;
using System.Windows.Forms;

namespace D2
{
    public partial class Main : Form
    {
        Thread threadWaitForWindowTitleRenaming;
        private frmAccountCreate _frmAccountCreate;
        private List<AccountInfo> _AccountProfiles;
        private string _MasterPassword = null;
        private string _Salt = null;
        public Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//���ñ�����
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //����˫����
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstProfiles.Items.Count > 0)
            {
                if (lstProfiles.SelectedItems.Count > 0)
                {
                    String SelectedProfileName = lstProfiles.SelectedItems[0].Text;
                    AccountInfo accountInfo = null;
                    for (int index = 0; index < _AccountProfiles.Count; index++)
                    {
                        if (_AccountProfiles[index].ProfileName.ToLowerInvariant() == SelectedProfileName.ToLowerInvariant())
                        {
                            accountInfo = _AccountProfiles[index];
                            break;
                        }
                    }
                    if (accountInfo == null) { return; }
                    try
                    {
                        Helpers.KillAllD2RInstanceCheckerHandle();
                        StartGameWithAccountProfile(accountInfo);
                    }
                    catch (Exception ex)
                    {
                        addApplicationLog("KillD2RInstanceChecker -> Exception occured -> " + ex.Message);
                        addApplicationLog("Please retry the operation, if it does fail, please check the logs for possible errors.");
                    }
                }
            }
        }

        private void addApplicationLog(string logdata, bool force = false)
        {
            try
            {
                //��ȡʱ��
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                //richTextBox1���һ��
                this.richTextBox1.AppendText($"{time}: {logdata}\r\n");

                //richTextBox1���������һ��
                this.richTextBox1.ScrollToCaret();

            }
            catch { }
        }



        private void RenameD2RWindowWithDelayThreadSafe(int PID, string WindowTitle, int DelayMilliseconds)
        {
            //addApplicationLog("WaitDelayForWindowTitleRenamingThreadSafe();");
            if (threadWaitForWindowTitleRenaming != null)
            {
                // try { threadWaitForWindowTitleRenaming.Abort(); } catch { }
                try { threadWaitForWindowTitleRenaming = null; } catch { }
            }

            object[] parameters = {
                PID.ToString(),
                WindowTitle,
                DelayMilliseconds.ToString()
            };

            //addApplicationLog("Starting Thread for WaitDelayForWindowTitleRenamingThreadSafe();");
            threadWaitForWindowTitleRenaming = new Thread(new ParameterizedThreadStart(_threadedRenameD2RWindowWithDelayThreadSafe));
            threadWaitForWindowTitleRenaming.Start(parameters);
        }

        private void _threadedRenameD2RWindowWithDelayThreadSafe(object obj)
        {
            //addApplicationLog("_threadedRenameD2RWindowWithDelayThreadSafe();");

            // Grab our parameters back
            object[] parameters = (object[])obj;

            // Attempt to grab a reference to the provided process by the given PID.
            Process gameProcess = null;
            int PID = Convert.ToInt32(parameters[0]);
            string WindowTitle = (string)parameters[1];
            int DelayMilliseconds = Convert.ToInt32(parameters[2]);

            if (DelayMilliseconds > 0)
            {
                Thread.Sleep(DelayMilliseconds);
            }

            try
            {
                gameProcess = Process.GetProcessById(PID);
                if (!gameProcess.HasExited)
                {
                    Helpers.SetWindowText(gameProcess.MainWindowHandle, WindowTitle);
                }
            }
            catch (ArgumentException aex)
            { // If for some reason this process do not exist or has died, let return immediately,
                addApplicationLog("_threadedRenameD2RWindowWithDelayThreadSafe failed to access gameProcess PID.\r\nMessage:" + aex.Message);
                return;
            }
        }

        private void StartGameWithAccountProfile(AccountInfo accountInfo)
        {
            try
            {

                //addApplicationLog("Launching Game (D2R.exe) with account: " + accountInfo.ProfileName);
                string realm = "us"; // default
                switch (ddRealm.SelectedIndex)
                {
                    case 0: { realm = "us"; break; }
                    case 1: { realm = "eu"; break; }
                    case 2: { realm = "kr"; break; }
                    default: { realm = "us"; break; }
                }

                Process gameProcess = Helpers.LaunchGame(
                    (optArgumentsNoSound.Checked ? " -ns -nosound " : "") +
                    (optArgumentsLowQuality.Checked ? " -lq " : "") +
                    (optArgumentsWindowed.Checked ? " -w " : "") +
                    " -username " + accountInfo.EmailAddress + " -password " + accountInfo.Password + " -address " + realm + ".actual.battle.net "
                    + (!string.IsNullOrEmpty(accountInfo.Mod) ? accountInfo.Mod : ""));

                addApplicationLog("��D2R�������гɹ���PID: " + gameProcess.Id.ToString());

                RenameD2RWindowWithDelayThreadSafe(gameProcess.Id, accountInfo.ProfileName, 7000);

                addApplicationLog("���ڸ���Ϊ : " + accountInfo.ProfileName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_frmAccountCreate != null)
                {
                    _frmAccountCreate.Dispose();
                    _frmAccountCreate = null;
                }

                _frmAccountCreate = new frmAccountCreate();
                _frmAccountCreate.OnCreateAccount += _frmAccountCreate_OnCreateAccount;
                _frmAccountCreate.OnCancel += _frmAccountCreate_OnCancel;
                _frmAccountCreate.ShowDialog(this);
            }
            catch { }


        }



        private void ReloadAccountProfiles()
        {
            if (lstProfiles.InvokeRequired)
            {
                lstProfiles.Invoke(new MethodInvoker(() => { ReloadAccountProfiles(); }));
                return;
            }

            try
            {
                //addApplicationLog("ReloadAccountProfiles()::start");

                _AccountProfiles = Helpers.getAccountProfiles();
                //addApplicationLog("ReloadAccountProfiles()::account detected: " + _AccountProfiles.Count.ToString());

                lstProfiles.Items.Clear();
                foreach (AccountInfo account in _AccountProfiles)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = account.ProfileName;
                        lvi.SubItems.Add(account.Mod);
                        addApplicationLog("���������ļ�()::�����˺� : " + account.ProfileName.ToLowerInvariant());
                        lstProfiles.Items.Add(lvi);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                //addApplicationLog("ReloadAccountProfiles()::end");
                lstProfiles.Columns[0].Width = 400;
                int lstWidth = lstProfiles.Width;
                lstProfiles.Columns[1].Width = lstWidth - 405;
            }
            catch { }
        }

        private void _frmAccountCreate_OnCreateAccount(string profileName, string email, string password, string mod)
        {
            try
            {
                if (_frmAccountCreate != null)
                {
                    _frmAccountCreate.Close();
                    _frmAccountCreate.Dispose();
                    _frmAccountCreate = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception (_frmAccountCreate_OnCreateAccount): " + ex.Message);
            }

            try
            {
                AccountInfo account = new AccountInfo()
                {
                    ProfileName = profileName,
                    EmailAddress = email,
                    Password = password,
                    Mod = mod
                };
                account.generateNewIV();

                account.WriteToBinaryFile(
                    Application.StartupPath + "\\" + profileName.ToLowerInvariant() + ".encrypted.json",
                    false);
                addApplicationLog("�����˺�: " + profileName);

                addApplicationLog("ˢ���˺��б�");

                ReloadAccountProfiles();

                MessageBox.Show(this,
                    "�˺���ӳɹ�.\r\n\r\n" +
                    "",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception (_frmAccountCreate_OnCreateAccount): " + ex.Message);
            }

            //addApplicationLog("Account created: " + profileName + ".");
        }
        private void _frmAccountCreate_OnCancel()
        {
            try
            {
                if (_frmAccountCreate != null)
                {
                    _frmAccountCreate.Dispose();
                    _frmAccountCreate = null;
                }
                //addApplicationLog("Account creation was cancelled by the user.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception (_frmAccountCreate_OnCancel): " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadAccountProfiles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstProfiles.Items.Count > 0)
                {
                    if (lstProfiles.SelectedItems.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show(this, "ȷ��ɾ��: " + lstProfiles.SelectedItems[0].Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            String ProfileName = lstProfiles.SelectedItems[0].Text;
                            try
                            {
                                File.Delete(Application.StartupPath + "\\" + ProfileName + ".encrypted.json");
                                lstProfiles.SelectedItems[0].Remove();
                                addApplicationLog("ɾ���˺�: " + ProfileName);
                                MessageBox.Show(this, "ɾ���˺�: " + ProfileName, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }

        private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProfiles.Items.Count > 0)
            {

                btnRemoveAccount.Visible = (lstProfiles.SelectedItems.Count > 0);
                btnRemoveAccount.Enabled = (lstProfiles.SelectedItems.Count > 0);
                btnStartAccount.Visible = (lstProfiles.SelectedItems.Count > 0);
                btnStartAccount.Enabled = (lstProfiles.SelectedItems.Count > 0);



                return;
            }
            btnRemoveAccount.Visible = false;
            btnStartAccount.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int flg = Helpers.KillAllD2RInstanceCheckerHandle_return();
                switch (flg)
                {
                    case 0:
                        addApplicationLog("ɱ���� -> �ɹ�");
                        break;
                    case -1:
                        addApplicationLog("ɱ���� -> ʧ�� -> δ����Check For Other Instances����");
                        break;
                    case -2:
                        addApplicationLog("ɱ���� -> ʧ�� -> handle.exe�ļ�������");
                        break;
                    case -3:
                        addApplicationLog("ɱ���� -> ʧ��");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                addApplicationLog("KillD2RInstanceChecker -> Exception occured -> " + ex.Message);
                addApplicationLog("Please retry the operation, if it does fail, please check the logs for possible errors.");
                addApplicationLog("ɱ���� -> ʧ��");
            }

        }
    }
}