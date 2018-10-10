namespace ProcessManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.lbl_ProgessInfo = new MetroFramework.Controls.MetroLabel();
            this.btn_removeFromAutostart = new MetroFramework.Controls.MetroButton();
            this.btn_addToAutostart = new MetroFramework.Controls.MetroButton();
            this.compare_btm = new MetroFramework.Controls.MetroButton();
            this.copyMD5_btm = new MetroFramework.Controls.MetroButton();
            this.cancel_btm = new MetroFramework.Controls.MetroButton();
            this.log_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.unlockDirAndDel_btm = new MetroFramework.Controls.MetroButton();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.unlockDir_btm = new MetroFramework.Controls.MetroButton();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.unlock_btm = new MetroFramework.Controls.MetroButton();
            this.deleteFile_btm = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.file_hash_lbl = new MetroFramework.Controls.MetroLabel();
            this.creationTime_lbl = new MetroFramework.Controls.MetroLabel();
            this.fileName_lbl = new MetroFramework.Controls.MetroLabel();
            this.size_lbl = new MetroFramework.Controls.MetroLabel();
            this.pause = new MetroFramework.Controls.MetroButton();
            this.pathToFile = new MetroFramework.Controls.MetroTextBox();
            this.start = new MetroFramework.Controls.MetroButton();
            this.pauseOnStart = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.history_listbx = new System.Windows.Forms.ListBox();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.listbx_FileWatcher = new System.Windows.Forms.ListBox();
            this.txtbx_file_filter = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.btn_file_selectDir = new MetroFramework.Controls.MetroButton();
            this.txtbx_file_path = new MetroFramework.Controls.MetroTextBox();
            this.btn_file_start = new MetroFramework.Controls.MetroButton();
            this.metroTabPage7 = new MetroFramework.Controls.MetroTabPage();
            this.ntn_clearListbx_killed = new MetroFramework.Controls.MetroButton();
            this.txtbx_procName = new MetroFramework.Controls.MetroTextBox();
            this.checkbx_spyOnly = new MetroFramework.Controls.MetroToggle();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.checkbx_safemode = new MetroFramework.Controls.MetroToggle();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.listbx_killed = new System.Windows.Forms.ListBox();
            this.listbx_whitelist = new System.Windows.Forms.ListBox();
            this.txtbx_pathtofile = new MetroFramework.Controls.MetroTextBox();
            this.btn_del = new MetroFramework.Controls.MetroButton();
            this.btn_add = new MetroFramework.Controls.MetroButton();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txtbx_ProcessName = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_setpassword = new MetroFramework.Controls.MetroButton();
            this.btn_deletePass = new MetroFramework.Controls.MetroButton();
            this.removeFromAutostart_btm = new MetroFramework.Controls.MetroButton();
            this.autostart_btm = new MetroFramework.Controls.MetroButton();
            this.icon_checkbx = new MetroFramework.Controls.MetroToggle();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.minimize_checkbx = new MetroFramework.Controls.MetroToggle();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.blacklistIsSorted = new MetroFramework.Controls.MetroToggle();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.symbols_txtbx = new System.Windows.Forms.RichTextBox();
            this.theme_lbl = new MetroFramework.Controls.MetroLabel();
            this.help_withId = new MetroFramework.Controls.MetroCheckBox();
            this.colorSwitcher = new MetroFramework.Controls.MetroComboBox();
            this.themeSwitcher = new MetroFramework.Controls.MetroComboBox();
            this.watermarkspeed = new MetroFramework.Controls.MetroTrackBar();
            this.color_lbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.watermark = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.pathToModule_lbl = new MetroFramework.Controls.MetroLabel();
            this.injectDll_private_btm = new MetroFramework.Controls.MetroButton();
            this.unselect_btm = new MetroFramework.Controls.MetroButton();
            this.refreshProcList = new MetroFramework.Controls.MetroButton();
            this.processList = new System.Windows.Forms.ListBox();
            this.processPid_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.SelectDll = new MetroFramework.Controls.MetroButton();
            this.selectProcess = new MetroFramework.Controls.MetroButton();
            this.kill_btm = new System.Windows.Forms.Button();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.pathToDll_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.getModules = new MetroFramework.Controls.MetroButton();
            this.processName_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.injectDll_btm = new MetroFramework.Controls.MetroButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.priority_lbl = new MetroFramework.Controls.MetroLabel();
            this.startTime_lbl = new MetroFramework.Controls.MetroLabel();
            this.pid_lbl = new MetroFramework.Controls.MetroLabel();
            this.name_lbl = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.btn_delPrc = new MetroFramework.Controls.MetroButton();
            this.listbx_processBlacklist = new System.Windows.Forms.ListBox();
            this.btn_addPrc = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.process_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.status_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.status_lbl = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.historyRefreshing = new System.Windows.Forms.Timer(this.components);
            this.watermark_timer = new System.Windows.Forms.Timer(this.components);
            this.sticks = new MetroFramework.Controls.MetroLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.watermark_top = new MetroFramework.Controls.MetroLabel();
            this.blacklistChecker = new System.Windows.Forms.Timer(this.components);
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SafeModeChecker = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.checkbx_blacklistEnabled = new MetroFramework.Controls.MetroToggle();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPage6.SuspendLayout();
            this.metroTabPage7.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.CheckProcessExists);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(681, 379);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 28);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage6);
            this.metroTabControl1.Controls.Add(this.metroTabPage7);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Location = new System.Drawing.Point(2, 23);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 6;
            this.metroTabControl1.Size = new System.Drawing.Size(706, 350);
            this.metroTabControl1.TabIndex = 13;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.lbl_ProgessInfo);
            this.metroTabPage1.Controls.Add(this.btn_removeFromAutostart);
            this.metroTabPage1.Controls.Add(this.btn_addToAutostart);
            this.metroTabPage1.Controls.Add(this.compare_btm);
            this.metroTabPage1.Controls.Add(this.copyMD5_btm);
            this.metroTabPage1.Controls.Add(this.cancel_btm);
            this.metroTabPage1.Controls.Add(this.log_txtbx);
            this.metroTabPage1.Controls.Add(this.unlockDirAndDel_btm);
            this.metroTabPage1.Controls.Add(this.progressBar1);
            this.metroTabPage1.Controls.Add(this.unlockDir_btm);
            this.metroTabPage1.Controls.Add(this.button1);
            this.metroTabPage1.Controls.Add(this.unlock_btm);
            this.metroTabPage1.Controls.Add(this.deleteFile_btm);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroPanel1);
            this.metroTabPage1.Controls.Add(this.pause);
            this.metroTabPage1.Controls.Add(this.pathToFile);
            this.metroTabPage1.Controls.Add(this.start);
            this.metroTabPage1.Controls.Add(this.pauseOnStart);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Main";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // lbl_ProgessInfo
            // 
            this.lbl_ProgessInfo.AutoSize = true;
            this.lbl_ProgessInfo.Location = new System.Drawing.Point(106, 228);
            this.lbl_ProgessInfo.Name = "lbl_ProgessInfo";
            this.lbl_ProgessInfo.Size = new System.Drawing.Size(36, 19);
            this.lbl_ProgessInfo.TabIndex = 36;
            this.lbl_ProgessInfo.Text = "0 / 0";
            // 
            // btn_removeFromAutostart
            // 
            this.btn_removeFromAutostart.Location = new System.Drawing.Point(441, 60);
            this.btn_removeFromAutostart.Name = "btn_removeFromAutostart";
            this.btn_removeFromAutostart.Size = new System.Drawing.Size(97, 23);
            this.btn_removeFromAutostart.TabIndex = 35;
            this.btn_removeFromAutostart.Text = "Remove to auto start";
            this.btn_removeFromAutostart.Click += new System.EventHandler(this.btn_removeFromAutostart_Click);
            // 
            // btn_addToAutostart
            // 
            this.btn_addToAutostart.Location = new System.Drawing.Point(335, 60);
            this.btn_addToAutostart.Name = "btn_addToAutostart";
            this.btn_addToAutostart.Size = new System.Drawing.Size(97, 23);
            this.btn_addToAutostart.TabIndex = 34;
            this.btn_addToAutostart.Text = "Add to auto start";
            this.btn_addToAutostart.Click += new System.EventHandler(this.btn_addToAutostart_Click);
            // 
            // compare_btm
            // 
            this.compare_btm.Location = new System.Drawing.Point(227, 60);
            this.compare_btm.Name = "compare_btm";
            this.compare_btm.Size = new System.Drawing.Size(97, 23);
            this.compare_btm.TabIndex = 33;
            this.compare_btm.Text = "Compare 2 files";
            this.compare_btm.Click += new System.EventHandler(this.compare_btm_Click);
            // 
            // copyMD5_btm
            // 
            this.copyMD5_btm.Location = new System.Drawing.Point(405, 156);
            this.copyMD5_btm.Name = "copyMD5_btm";
            this.copyMD5_btm.Size = new System.Drawing.Size(53, 23);
            this.copyMD5_btm.TabIndex = 32;
            this.copyMD5_btm.Text = "copy";
            this.copyMD5_btm.Click += new System.EventHandler(this.copyMD5_btm_Click);
            // 
            // cancel_btm
            // 
            this.cancel_btm.Enabled = false;
            this.cancel_btm.Location = new System.Drawing.Point(5, 227);
            this.cancel_btm.Name = "cancel_btm";
            this.cancel_btm.Size = new System.Drawing.Size(95, 23);
            this.cancel_btm.TabIndex = 31;
            this.cancel_btm.Text = "Cancel";
            this.cancel_btm.Click += new System.EventHandler(this.cancel_btm_Click);
            // 
            // log_txtbx
            // 
            this.log_txtbx.Enabled = false;
            this.log_txtbx.Location = new System.Drawing.Point(5, 256);
            this.log_txtbx.Name = "log_txtbx";
            this.log_txtbx.ReadOnly = true;
            this.log_txtbx.Size = new System.Drawing.Size(682, 23);
            this.log_txtbx.TabIndex = 30;
            // 
            // unlockDirAndDel_btm
            // 
            this.unlockDirAndDel_btm.Location = new System.Drawing.Point(547, 166);
            this.unlockDirAndDel_btm.Name = "unlockDirAndDel_btm";
            this.unlockDirAndDel_btm.Size = new System.Drawing.Size(124, 23);
            this.unlockDirAndDel_btm.TabIndex = 29;
            this.unlockDirAndDel_btm.Text = "Unlock dir and delete";
            this.unlockDirAndDel_btm.Click += new System.EventHandler(this.unlockDirAndDel_btm_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 285);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(682, 23);
            this.progressBar1.TabIndex = 28;
            // 
            // unlockDir_btm
            // 
            this.unlockDir_btm.Location = new System.Drawing.Point(547, 136);
            this.unlockDir_btm.Name = "unlockDir_btm";
            this.unlockDir_btm.Size = new System.Drawing.Size(124, 23);
            this.unlockDir_btm.TabIndex = 27;
            this.unlockDir_btm.Text = "Unlock dir";
            this.unlockDir_btm.Click += new System.EventHandler(this.unlockDir_btm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "•••";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // unlock_btm
            // 
            this.unlock_btm.Location = new System.Drawing.Point(547, 69);
            this.unlock_btm.Name = "unlock_btm";
            this.unlock_btm.Size = new System.Drawing.Size(124, 23);
            this.unlock_btm.TabIndex = 25;
            this.unlock_btm.Text = "Unlock file";
            this.unlock_btm.Click += new System.EventHandler(this.unlock_btm_Click);
            // 
            // deleteFile_btm
            // 
            this.deleteFile_btm.Location = new System.Drawing.Point(547, 98);
            this.deleteFile_btm.Name = "deleteFile_btm";
            this.deleteFile_btm.Size = new System.Drawing.Size(124, 23);
            this.deleteFile_btm.TabIndex = 24;
            this.deleteFile_btm.Text = "Unlock and delete File";
            this.deleteFile_btm.Click += new System.EventHandler(this.deleteFile_btm_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 102);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(32, 19);
            this.metroLabel2.TabIndex = 16;
            this.metroLabel2.Text = "File:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.file_hash_lbl);
            this.metroPanel1.Controls.Add(this.creationTime_lbl);
            this.metroPanel1.Controls.Add(this.fileName_lbl);
            this.metroPanel1.Controls.Add(this.size_lbl);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(53, 89);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(346, 126);
            this.metroPanel1.TabIndex = 23;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // file_hash_lbl
            // 
            this.file_hash_lbl.AutoSize = true;
            this.file_hash_lbl.Location = new System.Drawing.Point(18, 70);
            this.file_hash_lbl.Name = "file_hash_lbl";
            this.file_hash_lbl.Size = new System.Drawing.Size(40, 19);
            this.file_hash_lbl.TabIndex = 15;
            this.file_hash_lbl.Text = "MD5:";
            // 
            // creationTime_lbl
            // 
            this.creationTime_lbl.AutoSize = true;
            this.creationTime_lbl.Location = new System.Drawing.Point(18, 51);
            this.creationTime_lbl.Name = "creationTime_lbl";
            this.creationTime_lbl.Size = new System.Drawing.Size(96, 19);
            this.creationTime_lbl.TabIndex = 14;
            this.creationTime_lbl.Text = "Creation time: ";
            // 
            // fileName_lbl
            // 
            this.fileName_lbl.AutoSize = true;
            this.fileName_lbl.Location = new System.Drawing.Point(18, 13);
            this.fileName_lbl.Name = "fileName_lbl";
            this.fileName_lbl.Size = new System.Drawing.Size(48, 19);
            this.fileName_lbl.TabIndex = 12;
            this.fileName_lbl.Text = "Name:";
            // 
            // size_lbl
            // 
            this.size_lbl.AutoSize = true;
            this.size_lbl.Location = new System.Drawing.Point(18, 32);
            this.size_lbl.Name = "size_lbl";
            this.size_lbl.Size = new System.Drawing.Size(39, 19);
            this.size_lbl.TabIndex = 13;
            this.size_lbl.Text = "Size: ";
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(115, 60);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(97, 23);
            this.pause.TabIndex = 17;
            this.pause.Text = "Pause Process";
            this.pause.Click += new System.EventHandler(this.pause_Click_1);
            // 
            // pathToFile
            // 
            this.pathToFile.Location = new System.Drawing.Point(3, 5);
            this.pathToFile.Name = "pathToFile";
            this.pathToFile.ReadOnly = true;
            this.pathToFile.Size = new System.Drawing.Size(581, 25);
            this.pathToFile.TabIndex = 15;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(3, 60);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(97, 23);
            this.start.TabIndex = 14;
            this.start.Text = "Start Process";
            this.start.Click += new System.EventHandler(this.start_Click_1);
            // 
            // pauseOnStart
            // 
            this.pauseOnStart.AutoSize = true;
            this.pauseOnStart.Location = new System.Drawing.Point(3, 37);
            this.pauseOnStart.Name = "pauseOnStart";
            this.pauseOnStart.Size = new System.Drawing.Size(97, 15);
            this.pauseOnStart.TabIndex = 13;
            this.pauseOnStart.Text = "Pause on start";
            this.pauseOnStart.UseVisualStyleBackColor = true;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.history_listbx);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "History";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // history_listbx
            // 
            this.history_listbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.history_listbx.FormattingEnabled = true;
            this.history_listbx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.history_listbx.Location = new System.Drawing.Point(0, 2);
            this.history_listbx.Name = "history_listbx";
            this.history_listbx.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.history_listbx.Size = new System.Drawing.Size(694, 286);
            this.history_listbx.TabIndex = 2;
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.listbx_FileWatcher);
            this.metroTabPage6.Controls.Add(this.txtbx_file_filter);
            this.metroTabPage6.Controls.Add(this.metroLabel10);
            this.metroTabPage6.Controls.Add(this.btn_file_selectDir);
            this.metroTabPage6.Controls.Add(this.txtbx_file_path);
            this.metroTabPage6.Controls.Add(this.btn_file_start);
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage6.TabIndex = 5;
            this.metroTabPage6.Text = "File Watcher";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            // 
            // listbx_FileWatcher
            // 
            this.listbx_FileWatcher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbx_FileWatcher.FormattingEnabled = true;
            this.listbx_FileWatcher.Location = new System.Drawing.Point(3, 44);
            this.listbx_FileWatcher.Name = "listbx_FileWatcher";
            this.listbx_FileWatcher.Size = new System.Drawing.Size(674, 260);
            this.listbx_FileWatcher.TabIndex = 36;
            this.listbx_FileWatcher.DoubleClick += new System.EventHandler(this.listbx_FileWatcher_DoubleClick);
            // 
            // txtbx_file_filter
            // 
            this.txtbx_file_filter.Location = new System.Drawing.Point(569, 15);
            this.txtbx_file_filter.Name = "txtbx_file_filter";
            this.txtbx_file_filter.Size = new System.Drawing.Size(108, 23);
            this.txtbx_file_filter.TabIndex = 35;
            this.txtbx_file_filter.Text = "*.*";
            this.txtbx_file_filter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(517, 17);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(46, 19);
            this.metroLabel10.TabIndex = 34;
            this.metroLabel10.Text = "Filter: ";
            // 
            // btn_file_selectDir
            // 
            this.btn_file_selectDir.Location = new System.Drawing.Point(481, 15);
            this.btn_file_selectDir.Name = "btn_file_selectDir";
            this.btn_file_selectDir.Size = new System.Drawing.Size(36, 23);
            this.btn_file_selectDir.TabIndex = 33;
            this.btn_file_selectDir.Text = "•••";
            this.btn_file_selectDir.Click += new System.EventHandler(this.btn_file_selectDir_Click);
            // 
            // txtbx_file_path
            // 
            this.txtbx_file_path.Location = new System.Drawing.Point(84, 15);
            this.txtbx_file_path.Name = "txtbx_file_path";
            this.txtbx_file_path.Size = new System.Drawing.Size(394, 23);
            this.txtbx_file_path.TabIndex = 32;
            // 
            // btn_file_start
            // 
            this.btn_file_start.Location = new System.Drawing.Point(3, 15);
            this.btn_file_start.Name = "btn_file_start";
            this.btn_file_start.Size = new System.Drawing.Size(75, 23);
            this.btn_file_start.TabIndex = 31;
            this.btn_file_start.Text = "Start";
            this.btn_file_start.Click += new System.EventHandler(this.btn_file_start_Click);
            // 
            // metroTabPage7
            // 
            this.metroTabPage7.Controls.Add(this.ntn_clearListbx_killed);
            this.metroTabPage7.Controls.Add(this.txtbx_procName);
            this.metroTabPage7.Controls.Add(this.checkbx_spyOnly);
            this.metroTabPage7.Controls.Add(this.metroLabel13);
            this.metroTabPage7.Controls.Add(this.checkbx_safemode);
            this.metroTabPage7.Controls.Add(this.metroLabel12);
            this.metroTabPage7.Controls.Add(this.listbx_killed);
            this.metroTabPage7.Controls.Add(this.listbx_whitelist);
            this.metroTabPage7.Controls.Add(this.txtbx_pathtofile);
            this.metroTabPage7.Controls.Add(this.btn_del);
            this.metroTabPage7.Controls.Add(this.btn_add);
            this.metroTabPage7.Controls.Add(this.metroLabel11);
            this.metroTabPage7.Controls.Add(this.txtbx_ProcessName);
            this.metroTabPage7.HorizontalScrollbarBarColor = true;
            this.metroTabPage7.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage7.Name = "metroTabPage7";
            this.metroTabPage7.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage7.TabIndex = 6;
            this.metroTabPage7.Text = "Safe mode";
            this.metroTabPage7.VerticalScrollbarBarColor = true;
            // 
            // ntn_clearListbx_killed
            // 
            this.ntn_clearListbx_killed.Location = new System.Drawing.Point(471, 283);
            this.ntn_clearListbx_killed.Name = "ntn_clearListbx_killed";
            this.ntn_clearListbx_killed.Size = new System.Drawing.Size(227, 23);
            this.ntn_clearListbx_killed.TabIndex = 50;
            this.ntn_clearListbx_killed.Text = "Clear";
            this.ntn_clearListbx_killed.Click += new System.EventHandler(this.ntn_clearListbx_killed_Click);
            // 
            // txtbx_procName
            // 
            this.txtbx_procName.Location = new System.Drawing.Point(471, 14);
            this.txtbx_procName.Name = "txtbx_procName";
            this.txtbx_procName.Size = new System.Drawing.Size(227, 23);
            this.txtbx_procName.TabIndex = 49;
            // 
            // checkbx_spyOnly
            // 
            this.checkbx_spyOnly.AutoSize = true;
            this.checkbx_spyOnly.Location = new System.Drawing.Point(383, 14);
            this.checkbx_spyOnly.Name = "checkbx_spyOnly";
            this.checkbx_spyOnly.Size = new System.Drawing.Size(80, 17);
            this.checkbx_spyOnly.TabIndex = 48;
            this.checkbx_spyOnly.Text = "Off";
            this.checkbx_spyOnly.UseVisualStyleBackColor = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(303, 14);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(61, 19);
            this.metroLabel13.TabIndex = 47;
            this.metroLabel13.Text = "Spy only:";
            // 
            // checkbx_safemode
            // 
            this.checkbx_safemode.AutoSize = true;
            this.checkbx_safemode.Location = new System.Drawing.Point(154, 14);
            this.checkbx_safemode.Name = "checkbx_safemode";
            this.checkbx_safemode.Size = new System.Drawing.Size(80, 17);
            this.checkbx_safemode.TabIndex = 46;
            this.checkbx_safemode.Text = "Off";
            this.checkbx_safemode.UseVisualStyleBackColor = true;
            this.checkbx_safemode.CheckedChanged += new System.EventHandler(this.checkbx_safemode_CheckedChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(3, 14);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(76, 19);
            this.metroLabel12.TabIndex = 45;
            this.metroLabel12.Text = "Safe mode:";
            // 
            // listbx_killed
            // 
            this.listbx_killed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbx_killed.FormattingEnabled = true;
            this.listbx_killed.Location = new System.Drawing.Point(468, 69);
            this.listbx_killed.Name = "listbx_killed";
            this.listbx_killed.Size = new System.Drawing.Size(230, 208);
            this.listbx_killed.Sorted = true;
            this.listbx_killed.TabIndex = 13;
            this.listbx_killed.SelectedIndexChanged += new System.EventHandler(this.listbx_killed_SelectedIndexChanged);
            // 
            // listbx_whitelist
            // 
            this.listbx_whitelist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbx_whitelist.FormattingEnabled = true;
            this.listbx_whitelist.Location = new System.Drawing.Point(6, 70);
            this.listbx_whitelist.Name = "listbx_whitelist";
            this.listbx_whitelist.Size = new System.Drawing.Size(457, 234);
            this.listbx_whitelist.Sorted = true;
            this.listbx_whitelist.TabIndex = 12;
            // 
            // txtbx_pathtofile
            // 
            this.txtbx_pathtofile.Location = new System.Drawing.Point(471, 40);
            this.txtbx_pathtofile.Name = "txtbx_pathtofile";
            this.txtbx_pathtofile.Size = new System.Drawing.Size(227, 23);
            this.txtbx_pathtofile.TabIndex = 11;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(391, 40);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 10;
            this.btn_del.Text = "DEL";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(310, 41);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "ADD";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(1, 41);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(93, 19);
            this.metroLabel11.TabIndex = 8;
            this.metroLabel11.Text = "Process Name";
            // 
            // txtbx_ProcessName
            // 
            this.txtbx_ProcessName.Location = new System.Drawing.Point(95, 40);
            this.txtbx_ProcessName.Name = "txtbx_ProcessName";
            this.txtbx_ProcessName.Size = new System.Drawing.Size(209, 23);
            this.txtbx_ProcessName.TabIndex = 7;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroLabel5);
            this.metroTabPage3.Controls.Add(this.metroPanel2);
            this.metroTabPage3.Controls.Add(this.btn_setpassword);
            this.metroTabPage3.Controls.Add(this.btn_deletePass);
            this.metroTabPage3.Controls.Add(this.removeFromAutostart_btm);
            this.metroTabPage3.Controls.Add(this.autostart_btm);
            this.metroTabPage3.Controls.Add(this.icon_checkbx);
            this.metroTabPage3.Controls.Add(this.metroLabel9);
            this.metroTabPage3.Controls.Add(this.minimize_checkbx);
            this.metroTabPage3.Controls.Add(this.metroLabel8);
            this.metroTabPage3.Controls.Add(this.blacklistIsSorted);
            this.metroTabPage3.Controls.Add(this.metroLabel7);
            this.metroTabPage3.Controls.Add(this.symbols_txtbx);
            this.metroTabPage3.Controls.Add(this.theme_lbl);
            this.metroTabPage3.Controls.Add(this.help_withId);
            this.metroTabPage3.Controls.Add(this.colorSwitcher);
            this.metroTabPage3.Controls.Add(this.themeSwitcher);
            this.metroTabPage3.Controls.Add(this.watermarkspeed);
            this.metroTabPage3.Controls.Add(this.color_lbl);
            this.metroTabPage3.Controls.Add(this.metroLabel3);
            this.metroTabPage3.Controls.Add(this.watermark);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Info/Settings";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(400, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(143, 19);
            this.metroLabel5.TabIndex = 38;
            this.metroLabel5.Text = "Symbols(one per line): ";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.pictureBox9);
            this.metroPanel2.Controls.Add(this.pictureBox10);
            this.metroPanel2.Controls.Add(this.pictureBox11);
            this.metroPanel2.Controls.Add(this.pictureBox8);
            this.metroPanel2.Controls.Add(this.pictureBox7);
            this.metroPanel2.Controls.Add(this.pictureBox6);
            this.metroPanel2.Controls.Add(this.pictureBox5);
            this.metroPanel2.Controls.Add(this.pictureBox4);
            this.metroPanel2.Controls.Add(this.pictureBox3);
            this.metroPanel2.Controls.Add(this.pictureBox2);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(237, -8);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(300, 323);
            this.metroPanel2.TabIndex = 49;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(240, 32);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(30, 291);
            this.pictureBox9.TabIndex = 11;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.MouseLeave += new System.EventHandler(this.pictureBox9_MouseLeave);
            this.pictureBox9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox9_MouseMove);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(210, 32);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(30, 291);
            this.pictureBox10.TabIndex = 10;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.MouseLeave += new System.EventHandler(this.pictureBox10_MouseLeave);
            this.pictureBox10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox10_MouseMove);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Location = new System.Drawing.Point(270, 32);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(30, 291);
            this.pictureBox11.TabIndex = 9;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.MouseLeave += new System.EventHandler(this.pictureBox11_MouseLeave);
            this.pictureBox11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox11_MouseMove);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(180, 32);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(30, 291);
            this.pictureBox8.TabIndex = 8;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.MouseLeave += new System.EventHandler(this.pictureBox8_MouseLeave);
            this.pictureBox8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox8_MouseMove);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(150, 32);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 291);
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
            this.pictureBox7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox7_MouseMove);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(120, 9);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 314);
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
            this.pictureBox6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseMove);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(90, 9);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 314);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            this.pictureBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox5_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(60, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 314);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(30, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 314);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 314);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // btn_setpassword
            // 
            this.btn_setpassword.Location = new System.Drawing.Point(104, 271);
            this.btn_setpassword.Name = "btn_setpassword";
            this.btn_setpassword.Size = new System.Drawing.Size(97, 23);
            this.btn_setpassword.TabIndex = 48;
            this.btn_setpassword.Text = "Set password";
            this.btn_setpassword.Click += new System.EventHandler(this.btn_setpassword_Click);
            // 
            // btn_deletePass
            // 
            this.btn_deletePass.Location = new System.Drawing.Point(0, 271);
            this.btn_deletePass.Name = "btn_deletePass";
            this.btn_deletePass.Size = new System.Drawing.Size(97, 23);
            this.btn_deletePass.TabIndex = 47;
            this.btn_deletePass.Text = "Delete password";
            this.btn_deletePass.Click += new System.EventHandler(this.btn_deletePass_Click);
            // 
            // removeFromAutostart_btm
            // 
            this.removeFromAutostart_btm.Location = new System.Drawing.Point(104, 62);
            this.removeFromAutostart_btm.Name = "removeFromAutostart_btm";
            this.removeFromAutostart_btm.Size = new System.Drawing.Size(97, 23);
            this.removeFromAutostart_btm.TabIndex = 46;
            this.removeFromAutostart_btm.Text = "Remove from autostart";
            this.removeFromAutostart_btm.Click += new System.EventHandler(this.removeFromAutostart_btm_Click);
            // 
            // autostart_btm
            // 
            this.autostart_btm.Location = new System.Drawing.Point(1, 62);
            this.autostart_btm.Name = "autostart_btm";
            this.autostart_btm.Size = new System.Drawing.Size(97, 23);
            this.autostart_btm.TabIndex = 45;
            this.autostart_btm.Text = "Add to autostart";
            this.autostart_btm.Click += new System.EventHandler(this.autostart_btm_Click);
            // 
            // icon_checkbx
            // 
            this.icon_checkbx.AutoSize = true;
            this.icon_checkbx.Checked = true;
            this.icon_checkbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.icon_checkbx.Location = new System.Drawing.Point(154, 90);
            this.icon_checkbx.Name = "icon_checkbx";
            this.icon_checkbx.Size = new System.Drawing.Size(80, 17);
            this.icon_checkbx.TabIndex = 44;
            this.icon_checkbx.Text = "On";
            this.icon_checkbx.UseVisualStyleBackColor = true;
            this.icon_checkbx.CheckedChanged += new System.EventHandler(this.icon_checkbx_CheckedChanged);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(3, 88);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(36, 19);
            this.metroLabel9.TabIndex = 43;
            this.metroLabel9.Text = "Icon:";
            // 
            // minimize_checkbx
            // 
            this.minimize_checkbx.AutoSize = true;
            this.minimize_checkbx.Checked = true;
            this.minimize_checkbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimize_checkbx.Location = new System.Drawing.Point(154, 109);
            this.minimize_checkbx.Name = "minimize_checkbx";
            this.minimize_checkbx.Size = new System.Drawing.Size(80, 17);
            this.minimize_checkbx.TabIndex = 42;
            this.minimize_checkbx.Text = "On";
            this.minimize_checkbx.UseVisualStyleBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(3, 107);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(97, 19);
            this.metroLabel8.TabIndex = 41;
            this.metroLabel8.Text = "Auto minimize:";
            // 
            // blacklistIsSorted
            // 
            this.blacklistIsSorted.AutoSize = true;
            this.blacklistIsSorted.Checked = true;
            this.blacklistIsSorted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blacklistIsSorted.Location = new System.Drawing.Point(154, 128);
            this.blacklistIsSorted.Name = "blacklistIsSorted";
            this.blacklistIsSorted.Size = new System.Drawing.Size(80, 17);
            this.blacklistIsSorted.TabIndex = 40;
            this.blacklistIsSorted.Text = "On";
            this.blacklistIsSorted.UseVisualStyleBackColor = true;
            this.blacklistIsSorted.CheckedChanged += new System.EventHandler(this.blacklistIsSorted_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 126);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(103, 19);
            this.metroLabel7.TabIndex = 39;
            this.metroLabel7.Text = "Black list sorted:";
            // 
            // symbols_txtbx
            // 
            this.symbols_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.symbols_txtbx.Location = new System.Drawing.Point(543, 3);
            this.symbols_txtbx.Name = "symbols_txtbx";
            this.symbols_txtbx.Size = new System.Drawing.Size(145, 308);
            this.symbols_txtbx.TabIndex = 37;
            this.symbols_txtbx.Text = "►\n*\n☼\n●\n♥\n▲\n❍\n✜\n㋛\n§\n↔\n☢\n√\nツ\n★\n☆\n♕\n✹\n☏\n♫\n〄\n❂\n⊚";
            // 
            // theme_lbl
            // 
            this.theme_lbl.AutoSize = true;
            this.theme_lbl.Location = new System.Drawing.Point(1, 244);
            this.theme_lbl.Name = "theme_lbl";
            this.theme_lbl.Size = new System.Drawing.Size(52, 19);
            this.theme_lbl.TabIndex = 22;
            this.theme_lbl.Text = "Theme:";
            // 
            // help_withId
            // 
            this.help_withId.AutoSize = true;
            this.help_withId.Checked = true;
            this.help_withId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.help_withId.Location = new System.Drawing.Point(3, 183);
            this.help_withId.Name = "help_withId";
            this.help_withId.Size = new System.Drawing.Size(56, 15);
            this.help_withId.TabIndex = 34;
            this.help_withId.Text = "helper";
            this.help_withId.UseVisualStyleBackColor = true;
            // 
            // colorSwitcher
            // 
            this.colorSwitcher.FormattingEnabled = true;
            this.colorSwitcher.ItemHeight = 23;
            this.colorSwitcher.Items.AddRange(new object[] {
            "Default",
            "White",
            "Black",
            "Blue",
            "Lime",
            "Teal",
            "Orange",
            "Brown",
            "Magenta",
            "Pink",
            "Purple",
            "Red"});
            this.colorSwitcher.Location = new System.Drawing.Point(53, 204);
            this.colorSwitcher.Name = "colorSwitcher";
            this.colorSwitcher.Size = new System.Drawing.Size(183, 29);
            this.colorSwitcher.TabIndex = 19;
            this.colorSwitcher.SelectedIndexChanged += new System.EventHandler(this.colorSwitcher_SelectedIndexChanged);
            // 
            // themeSwitcher
            // 
            this.themeSwitcher.FormattingEnabled = true;
            this.themeSwitcher.ItemHeight = 23;
            this.themeSwitcher.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.themeSwitcher.Location = new System.Drawing.Point(53, 239);
            this.themeSwitcher.Name = "themeSwitcher";
            this.themeSwitcher.Size = new System.Drawing.Size(183, 29);
            this.themeSwitcher.TabIndex = 21;
            this.themeSwitcher.SelectedIndexChanged += new System.EventHandler(this.themeSwitcher_SelectedIndexChanged_1);
            // 
            // watermarkspeed
            // 
            this.watermarkspeed.BackColor = System.Drawing.Color.Transparent;
            this.watermarkspeed.Location = new System.Drawing.Point(125, 145);
            this.watermarkspeed.Maximum = 1500;
            this.watermarkspeed.Minimum = 100;
            this.watermarkspeed.Name = "watermarkspeed";
            this.watermarkspeed.Size = new System.Drawing.Size(109, 23);
            this.watermarkspeed.TabIndex = 35;
            this.watermarkspeed.Value = 400;
            this.watermarkspeed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.watermarkspeed_Scroll);
            // 
            // color_lbl
            // 
            this.color_lbl.AutoSize = true;
            this.color_lbl.Location = new System.Drawing.Point(1, 209);
            this.color_lbl.Name = "color_lbl";
            this.color_lbl.Size = new System.Drawing.Size(46, 19);
            this.color_lbl.TabIndex = 20;
            this.color_lbl.Text = "Color:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 145);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(116, 19);
            this.metroLabel3.TabIndex = 36;
            this.metroLabel3.Text = "Watermark speed:";
            // 
            // watermark
            // 
            this.watermark.AutoSize = true;
            this.watermark.Location = new System.Drawing.Point(3, 24);
            this.watermark.Name = "watermark";
            this.watermark.Size = new System.Drawing.Size(133, 19);
            this.watermark.TabIndex = 23;
            this.watermark.Text = "Coded by Tavvi in C#";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.pathToModule_lbl);
            this.metroTabPage2.Controls.Add(this.injectDll_private_btm);
            this.metroTabPage2.Controls.Add(this.unselect_btm);
            this.metroTabPage2.Controls.Add(this.refreshProcList);
            this.metroTabPage2.Controls.Add(this.processList);
            this.metroTabPage2.Controls.Add(this.processPid_txtbx);
            this.metroTabPage2.Controls.Add(this.SelectDll);
            this.metroTabPage2.Controls.Add(this.selectProcess);
            this.metroTabPage2.Controls.Add(this.kill_btm);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.pathToDll_txtbx);
            this.metroTabPage2.Controls.Add(this.getModules);
            this.metroTabPage2.Controls.Add(this.processName_txtbx);
            this.metroTabPage2.Controls.Add(this.injectDll_btm);
            this.metroTabPage2.Controls.Add(this.listBox1);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.Controls.Add(this.priority_lbl);
            this.metroTabPage2.Controls.Add(this.startTime_lbl);
            this.metroTabPage2.Controls.Add(this.pid_lbl);
            this.metroTabPage2.Controls.Add(this.name_lbl);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Process";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // pathToModule_lbl
            // 
            this.pathToModule_lbl.AutoSize = true;
            this.pathToModule_lbl.Location = new System.Drawing.Point(5, 285);
            this.pathToModule_lbl.Name = "pathToModule_lbl";
            this.pathToModule_lbl.Size = new System.Drawing.Size(53, 19);
            this.pathToModule_lbl.TabIndex = 34;
            this.pathToModule_lbl.Text = "No info";
            // 
            // injectDll_private_btm
            // 
            this.injectDll_private_btm.Location = new System.Drawing.Point(373, 167);
            this.injectDll_private_btm.Name = "injectDll_private_btm";
            this.injectDll_private_btm.Size = new System.Drawing.Size(97, 23);
            this.injectDll_private_btm.TabIndex = 33;
            this.injectDll_private_btm.Text = "Inject dll(v2)";
            this.injectDll_private_btm.Click += new System.EventHandler(this.injectDll_private_btm_Click);
            // 
            // unselect_btm
            // 
            this.unselect_btm.Location = new System.Drawing.Point(372, 196);
            this.unselect_btm.Name = "unselect_btm";
            this.unselect_btm.Size = new System.Drawing.Size(97, 23);
            this.unselect_btm.TabIndex = 32;
            this.unselect_btm.Text = "Unselect process";
            this.unselect_btm.Click += new System.EventHandler(this.unselect_btm_Click);
            // 
            // refreshProcList
            // 
            this.refreshProcList.Location = new System.Drawing.Point(373, 109);
            this.refreshProcList.Name = "refreshProcList";
            this.refreshProcList.Size = new System.Drawing.Size(97, 23);
            this.refreshProcList.TabIndex = 31;
            this.refreshProcList.Text = "Refresh List";
            this.refreshProcList.Click += new System.EventHandler(this.refreshProcList_Click);
            // 
            // processList
            // 
            this.processList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(475, 4);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(196, 273);
            this.processList.TabIndex = 30;
            this.processList.SelectedIndexChanged += new System.EventHandler(this.processList_SelectedIndexChanged);
            // 
            // processPid_txtbx
            // 
            this.processPid_txtbx.Location = new System.Drawing.Point(327, 10);
            this.processPid_txtbx.Name = "processPid_txtbx";
            this.processPid_txtbx.Size = new System.Drawing.Size(58, 23);
            this.processPid_txtbx.TabIndex = 29;
            // 
            // SelectDll
            // 
            this.SelectDll.Location = new System.Drawing.Point(408, 39);
            this.SelectDll.Name = "SelectDll";
            this.SelectDll.Size = new System.Drawing.Size(62, 23);
            this.SelectDll.TabIndex = 27;
            this.SelectDll.Text = "•••";
            this.SelectDll.Click += new System.EventHandler(this.SelectDll_Click);
            // 
            // selectProcess
            // 
            this.selectProcess.Location = new System.Drawing.Point(391, 10);
            this.selectProcess.Name = "selectProcess";
            this.selectProcess.Size = new System.Drawing.Size(79, 23);
            this.selectProcess.TabIndex = 26;
            this.selectProcess.Text = "Add by pID";
            this.selectProcess.Click += new System.EventHandler(this.selectProcess_Click);
            // 
            // kill_btm
            // 
            this.kill_btm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kill_btm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kill_btm.ForeColor = System.Drawing.Color.Red;
            this.kill_btm.Location = new System.Drawing.Point(372, 225);
            this.kill_btm.Name = "kill_btm";
            this.kill_btm.Size = new System.Drawing.Size(97, 23);
            this.kill_btm.TabIndex = 20;
            this.kill_btm.Text = "KILL";
            this.kill_btm.UseVisualStyleBackColor = true;
            this.kill_btm.Click += new System.EventHandler(this.kill_btm_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 41);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(27, 19);
            this.metroLabel4.TabIndex = 25;
            this.metroLabel4.Text = "Dll:";
            // 
            // pathToDll_txtbx
            // 
            this.pathToDll_txtbx.Location = new System.Drawing.Point(65, 39);
            this.pathToDll_txtbx.Name = "pathToDll_txtbx";
            this.pathToDll_txtbx.ReadOnly = true;
            this.pathToDll_txtbx.Size = new System.Drawing.Size(337, 23);
            this.pathToDll_txtbx.TabIndex = 18;
            // 
            // getModules
            // 
            this.getModules.Location = new System.Drawing.Point(373, 80);
            this.getModules.Name = "getModules";
            this.getModules.Size = new System.Drawing.Size(97, 23);
            this.getModules.TabIndex = 22;
            this.getModules.Text = "Refresh Modules";
            this.getModules.Click += new System.EventHandler(this.getModules_Click_1);
            // 
            // processName_txtbx
            // 
            this.processName_txtbx.Location = new System.Drawing.Point(65, 10);
            this.processName_txtbx.Name = "processName_txtbx";
            this.processName_txtbx.ReadOnly = true;
            this.processName_txtbx.Size = new System.Drawing.Size(256, 23);
            this.processName_txtbx.TabIndex = 18;
            // 
            // injectDll_btm
            // 
            this.injectDll_btm.Location = new System.Drawing.Point(372, 138);
            this.injectDll_btm.Name = "injectDll_btm";
            this.injectDll_btm.Size = new System.Drawing.Size(97, 23);
            this.injectDll_btm.TabIndex = 24;
            this.injectDll_btm.Text = "Inject dll(simple)";
            this.injectDll_btm.Click += new System.EventHandler(this.injectDll_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(185, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(182, 208);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(56, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Process:";
            // 
            // priority_lbl
            // 
            this.priority_lbl.AutoSize = true;
            this.priority_lbl.Location = new System.Drawing.Point(3, 176);
            this.priority_lbl.Name = "priority_lbl";
            this.priority_lbl.Size = new System.Drawing.Size(58, 19);
            this.priority_lbl.TabIndex = 15;
            this.priority_lbl.Text = "Priority: ";
            // 
            // startTime_lbl
            // 
            this.startTime_lbl.AutoSize = true;
            this.startTime_lbl.Location = new System.Drawing.Point(3, 157);
            this.startTime_lbl.Name = "startTime_lbl";
            this.startTime_lbl.Size = new System.Drawing.Size(70, 19);
            this.startTime_lbl.TabIndex = 2;
            this.startTime_lbl.Text = "Start time:";
            // 
            // pid_lbl
            // 
            this.pid_lbl.AutoSize = true;
            this.pid_lbl.Location = new System.Drawing.Point(3, 138);
            this.pid_lbl.Name = "pid_lbl";
            this.pid_lbl.Size = new System.Drawing.Size(35, 19);
            this.pid_lbl.TabIndex = 1;
            this.pid_lbl.Text = "Pid: ";
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Location = new System.Drawing.Point(3, 119);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(52, 19);
            this.name_lbl.TabIndex = 0;
            this.name_lbl.Text = "Name: ";
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.checkbx_blacklistEnabled);
            this.metroTabPage5.Controls.Add(this.metroLabel14);
            this.metroTabPage5.Controls.Add(this.btn_delPrc);
            this.metroTabPage5.Controls.Add(this.listbx_processBlacklist);
            this.metroTabPage5.Controls.Add(this.btn_addPrc);
            this.metroTabPage5.Controls.Add(this.metroLabel6);
            this.metroTabPage5.Controls.Add(this.process_txtbx);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(698, 311);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = " Blacklist";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            // 
            // btn_delPrc
            // 
            this.btn_delPrc.Location = new System.Drawing.Point(390, 5);
            this.btn_delPrc.Name = "btn_delPrc";
            this.btn_delPrc.Size = new System.Drawing.Size(75, 23);
            this.btn_delPrc.TabIndex = 6;
            this.btn_delPrc.Text = "DEL";
            this.btn_delPrc.Click += new System.EventHandler(this.removeProcess_Click);
            // 
            // listbx_processBlacklist
            // 
            this.listbx_processBlacklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbx_processBlacklist.FormattingEnabled = true;
            this.listbx_processBlacklist.Location = new System.Drawing.Point(0, 35);
            this.listbx_processBlacklist.Name = "listbx_processBlacklist";
            this.listbx_processBlacklist.Size = new System.Drawing.Size(698, 273);
            this.listbx_processBlacklist.Sorted = true;
            this.listbx_processBlacklist.TabIndex = 5;
            // 
            // btn_addPrc
            // 
            this.btn_addPrc.Location = new System.Drawing.Point(309, 5);
            this.btn_addPrc.Name = "btn_addPrc";
            this.btn_addPrc.Size = new System.Drawing.Size(75, 23);
            this.btn_addPrc.TabIndex = 4;
            this.btn_addPrc.Text = "ADD";
            this.btn_addPrc.Click += new System.EventHandler(this.addProcess_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(0, 6);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(93, 19);
            this.metroLabel6.TabIndex = 3;
            this.metroLabel6.Text = "Process Name";
            // 
            // process_txtbx
            // 
            this.process_txtbx.Location = new System.Drawing.Point(94, 5);
            this.process_txtbx.Name = "process_txtbx";
            this.process_txtbx.Size = new System.Drawing.Size(209, 23);
            this.process_txtbx.TabIndex = 2;
            // 
            // status_txtbx
            // 
            this.status_txtbx.Location = new System.Drawing.Point(59, 375);
            this.status_txtbx.Name = "status_txtbx";
            this.status_txtbx.ReadOnly = true;
            this.status_txtbx.Size = new System.Drawing.Size(129, 23);
            this.status_txtbx.TabIndex = 19;
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Location = new System.Drawing.Point(2, 377);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(51, 19);
            this.status_lbl.TabIndex = 18;
            this.status_lbl.Text = "STATUS";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // historyRefreshing
            // 
            this.historyRefreshing.Enabled = true;
            this.historyRefreshing.Interval = 1000;
            this.historyRefreshing.Tick += new System.EventHandler(this.historyRefreshing_Tick);
            // 
            // watermark_timer
            // 
            this.watermark_timer.Enabled = true;
            this.watermark_timer.Interval = 700;
            this.watermark_timer.Tick += new System.EventHandler(this.watermark_timer_Tick);
            // 
            // sticks
            // 
            this.sticks.AutoSize = true;
            this.sticks.Location = new System.Drawing.Point(191, 376);
            this.sticks.Name = "sticks";
            this.sticks.Size = new System.Drawing.Size(474, 19);
            this.sticks.TabIndex = 37;
            this.sticks.Text = "\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\" +
    "/\\/\\/\\/\\/\\/\\";
            // 
            // watermark_top
            // 
            this.watermark_top.AutoSize = true;
            this.watermark_top.Location = new System.Drawing.Point(3, 5);
            this.watermark_top.Name = "watermark_top";
            this.watermark_top.Size = new System.Drawing.Size(12, 19);
            this.watermark_top.TabIndex = 38;
            this.watermark_top.Text = ".";
            // 
            // blacklistChecker
            // 
            this.blacklistChecker.Enabled = true;
            this.blacklistChecker.Interval = 3000;
            this.blacklistChecker.Tick += new System.EventHandler(this.blacklistChecker_Tick);
            // 
            // icon
            // 
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "Process Manager";
            this.icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.icon_MouseClick);
            // 
            // SafeModeChecker
            // 
            this.SafeModeChecker.Enabled = true;
            this.SafeModeChecker.Interval = 500;
            this.SafeModeChecker.Tick += new System.EventHandler(this.SafeModeChecker_Tick);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);
            // 
            // checkbx_blacklistEnabled
            // 
            this.checkbx_blacklistEnabled.AutoSize = true;
            this.checkbx_blacklistEnabled.Checked = true;
            this.checkbx_blacklistEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbx_blacklistEnabled.Location = new System.Drawing.Point(587, 8);
            this.checkbx_blacklistEnabled.Name = "checkbx_blacklistEnabled";
            this.checkbx_blacklistEnabled.Size = new System.Drawing.Size(80, 17);
            this.checkbx_blacklistEnabled.TabIndex = 42;
            this.checkbx_blacklistEnabled.Text = "On";
            this.checkbx_blacklistEnabled.UseVisualStyleBackColor = true;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(469, 6);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(112, 19);
            this.metroLabel14.TabIndex = 41;
            this.metroLabel14.Text = "Black list enabled:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 400);
            this.Controls.Add(this.watermark_top);
            this.Controls.Add(this.sticks);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.status_txtbx);
            this.Controls.Add(this.status_lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Text = "Process Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage6.ResumeLayout(false);
            this.metroTabPage6.PerformLayout();
            this.metroTabPage7.ResumeLayout(false);
            this.metroTabPage7.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton getModules;
        private System.Windows.Forms.Button kill_btm;
        private MetroFramework.Controls.MetroTextBox status_txtbx;
        private MetroFramework.Controls.MetroLabel status_lbl;
        private MetroFramework.Controls.MetroButton pause;
        private MetroFramework.Controls.MetroTextBox pathToFile;
        private MetroFramework.Controls.MetroButton start;
        private MetroFramework.Controls.MetroCheckBox pauseOnStart;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel creationTime_lbl;
        private MetroFramework.Controls.MetroLabel name_lbl;
        private MetroFramework.Controls.MetroLabel fileName_lbl;
        private MetroFramework.Controls.MetroLabel size_lbl;
        private MetroFramework.Controls.MetroLabel pid_lbl;
        private MetroFramework.Controls.MetroLabel startTime_lbl;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroLabel watermark;
        private MetroFramework.Controls.MetroLabel theme_lbl;
        private MetroFramework.Controls.MetroComboBox themeSwitcher;
        private MetroFramework.Controls.MetroLabel color_lbl;
        private MetroFramework.Controls.MetroComboBox colorSwitcher;
        private System.Windows.Forms.ListBox history_listbx;
        private System.Windows.Forms.Timer historyRefreshing;
        private MetroFramework.Controls.MetroLabel priority_lbl;
        private MetroFramework.Controls.MetroButton injectDll_btm;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroButton SelectDll;
        private MetroFramework.Controls.MetroButton selectProcess;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox pathToDll_txtbx;
        private MetroFramework.Controls.MetroTextBox processName_txtbx;
        private MetroFramework.Controls.MetroTextBox processPid_txtbx;
        private System.Windows.Forms.ListBox processList;
        private MetroFramework.Controls.MetroButton refreshProcList;
        private MetroFramework.Controls.MetroButton unselect_btm;
        private MetroFramework.Controls.MetroButton injectDll_private_btm;
        private MetroFramework.Controls.MetroCheckBox help_withId;
        private MetroFramework.Controls.MetroLabel pathToModule_lbl;
        private System.Windows.Forms.Timer watermark_timer;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTrackBar watermarkspeed;
        private MetroFramework.Controls.MetroLabel sticks;
        private MetroFramework.Controls.MetroButton deleteFile_btm;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroButton unlock_btm;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton unlockDir_btm;
        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private MetroFramework.Controls.MetroButton unlockDirAndDel_btm;
        private MetroFramework.Controls.MetroTextBox log_txtbx;
        private MetroFramework.Controls.MetroButton cancel_btm;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.RichTextBox symbols_txtbx;
        private MetroFramework.Controls.MetroLabel watermark_top;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private System.Windows.Forms.ListBox listbx_processBlacklist;
        private MetroFramework.Controls.MetroButton btn_addPrc;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox process_txtbx;
        private MetroFramework.Controls.MetroButton btn_delPrc;
        private MetroFramework.Controls.MetroToggle blacklistIsSorted;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.Timer blacklistChecker;
        private MetroFramework.Controls.MetroToggle minimize_checkbx;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel file_hash_lbl;
        private MetroFramework.Controls.MetroButton copyMD5_btm;
        private MetroFramework.Controls.MetroButton compare_btm;
        private System.Windows.Forms.NotifyIcon icon;
        private MetroFramework.Controls.MetroToggle icon_checkbx;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private MetroFramework.Controls.MetroButton autostart_btm;
        private MetroFramework.Controls.MetroButton removeFromAutostart_btm;
        private MetroFramework.Controls.MetroTabPage metroTabPage7;
        private System.Windows.Forms.ListBox listbx_killed;
        private System.Windows.Forms.ListBox listbx_whitelist;
        private MetroFramework.Controls.MetroTextBox txtbx_pathtofile;
        private MetroFramework.Controls.MetroButton btn_del;
        private MetroFramework.Controls.MetroButton btn_add;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox txtbx_ProcessName;
        private MetroFramework.Controls.MetroToggle checkbx_safemode;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private System.Windows.Forms.Timer SafeModeChecker;
        private MetroFramework.Controls.MetroToggle checkbx_spyOnly;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox txtbx_procName;
        private MetroFramework.Controls.MetroButton ntn_clearListbx_killed;
        private MetroFramework.Controls.MetroButton btn_deletePass;
        private MetroFramework.Controls.MetroButton btn_setpassword;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroButton btn_addToAutostart;
        private MetroFramework.Controls.MetroButton btn_removeFromAutostart;
        private MetroFramework.Controls.MetroLabel lbl_ProgessInfo;
        private MetroFramework.Controls.MetroTextBox txtbx_file_filter;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroButton btn_file_selectDir;
        private MetroFramework.Controls.MetroTextBox txtbx_file_path;
        private MetroFramework.Controls.MetroButton btn_file_start;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.ListBox listbx_FileWatcher;
        private MetroFramework.Controls.MetroToggle checkbx_blacklistEnabled;
        private MetroFramework.Controls.MetroLabel metroLabel14;
    }
}

