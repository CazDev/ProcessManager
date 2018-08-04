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
            this.creationTime_lbl = new MetroFramework.Controls.MetroLabel();
            this.fileName_lbl = new MetroFramework.Controls.MetroLabel();
            this.size_lbl = new MetroFramework.Controls.MetroLabel();
            this.pause = new MetroFramework.Controls.MetroButton();
            this.pathToFile = new MetroFramework.Controls.MetroTextBox();
            this.start = new MetroFramework.Controls.MetroButton();
            this.pauseOnStart = new MetroFramework.Controls.MetroCheckBox();
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
            this.removeProcess = new MetroFramework.Controls.MetroButton();
            this.processBlacklist_listbx = new System.Windows.Forms.ListBox();
            this.addProcess = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.process_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.optimization_checkbx = new MetroFramework.Controls.MetroToggle();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.blacklistIsSorted = new MetroFramework.Controls.MetroToggle();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.symbols_txtbx = new System.Windows.Forms.RichTextBox();
            this.theme_lbl = new MetroFramework.Controls.MetroLabel();
            this.help_withId = new MetroFramework.Controls.MetroCheckBox();
            this.colorSwitcher = new MetroFramework.Controls.MetroComboBox();
            this.themeSwitcher = new MetroFramework.Controls.MetroComboBox();
            this.watermarkspeed = new MetroFramework.Controls.MetroTrackBar();
            this.color_lbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.watermark = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.history_listbx = new System.Windows.Forms.ListBox();
            this.status_txtbx = new MetroFramework.Controls.MetroTextBox();
            this.status_lbl = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.historyRefreshing = new System.Windows.Forms.Timer(this.components);
            this.watermark_timer = new System.Windows.Forms.Timer(this.components);
            this.sticks = new MetroFramework.Controls.MetroLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.watermark_top = new MetroFramework.Controls.MetroLabel();
            this.blacklistChecker = new System.Windows.Forms.Timer(this.components);
            this.file_hash_lbl = new MetroFramework.Controls.MetroLabel();
            this.copyMD5_btm = new MetroFramework.Controls.MetroButton();
            this.compare_btm = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Location = new System.Drawing.Point(2, 23);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(706, 350);
            this.metroTabControl1.TabIndex = 13;
            // 
            // metroTabPage1
            // 
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
            // cancel_btm
            // 
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
            this.selectProcess.Text = "Add with pID";
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
            this.metroTabPage5.Controls.Add(this.removeProcess);
            this.metroTabPage5.Controls.Add(this.processBlacklist_listbx);
            this.metroTabPage5.Controls.Add(this.addProcess);
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
            // removeProcess
            // 
            this.removeProcess.Location = new System.Drawing.Point(390, 21);
            this.removeProcess.Name = "removeProcess";
            this.removeProcess.Size = new System.Drawing.Size(75, 23);
            this.removeProcess.TabIndex = 6;
            this.removeProcess.Text = "DEL";
            this.removeProcess.Click += new System.EventHandler(this.removeProcess_Click);
            // 
            // processBlacklist_listbx
            // 
            this.processBlacklist_listbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processBlacklist_listbx.FormattingEnabled = true;
            this.processBlacklist_listbx.Location = new System.Drawing.Point(3, 50);
            this.processBlacklist_listbx.Name = "processBlacklist_listbx";
            this.processBlacklist_listbx.Size = new System.Drawing.Size(687, 260);
            this.processBlacklist_listbx.Sorted = true;
            this.processBlacklist_listbx.TabIndex = 5;
            // 
            // addProcess
            // 
            this.addProcess.Location = new System.Drawing.Point(309, 21);
            this.addProcess.Name = "addProcess";
            this.addProcess.Size = new System.Drawing.Size(75, 23);
            this.addProcess.TabIndex = 4;
            this.addProcess.Text = "ADD";
            this.addProcess.Click += new System.EventHandler(this.addProcess_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(0, 22);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(93, 19);
            this.metroLabel6.TabIndex = 3;
            this.metroLabel6.Text = "Process Name";
            // 
            // process_txtbx
            // 
            this.process_txtbx.Location = new System.Drawing.Point(94, 21);
            this.process_txtbx.Name = "process_txtbx";
            this.process_txtbx.Size = new System.Drawing.Size(209, 23);
            this.process_txtbx.TabIndex = 2;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.optimization_checkbx);
            this.metroTabPage3.Controls.Add(this.metroLabel8);
            this.metroTabPage3.Controls.Add(this.blacklistIsSorted);
            this.metroTabPage3.Controls.Add(this.metroLabel7);
            this.metroTabPage3.Controls.Add(this.metroLabel5);
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
            // optimization_checkbx
            // 
            this.optimization_checkbx.AutoSize = true;
            this.optimization_checkbx.Checked = true;
            this.optimization_checkbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optimization_checkbx.Location = new System.Drawing.Point(154, 109);
            this.optimization_checkbx.Name = "optimization_checkbx";
            this.optimization_checkbx.Size = new System.Drawing.Size(80, 17);
            this.optimization_checkbx.TabIndex = 42;
            this.optimization_checkbx.Text = "On";
            this.optimization_checkbx.UseVisualStyleBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(3, 107);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(88, 19);
            this.metroLabel8.TabIndex = 41;
            this.metroLabel8.Text = "Optimization:";
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
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(400, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(143, 19);
            this.metroLabel5.TabIndex = 38;
            this.metroLabel5.Text = "Symbols(one per line): ";
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
            this.blacklistChecker.Interval = 1000;
            this.blacklistChecker.Tick += new System.EventHandler(this.blacklistChecker_Tick);
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
            // copyMD5_btm
            // 
            this.copyMD5_btm.Location = new System.Drawing.Point(405, 156);
            this.copyMD5_btm.Name = "copyMD5_btm";
            this.copyMD5_btm.Size = new System.Drawing.Size(53, 23);
            this.copyMD5_btm.TabIndex = 32;
            this.copyMD5_btm.Text = "copy";
            this.copyMD5_btm.Click += new System.EventHandler(this.copyMD5_btm_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
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
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage5.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.metroTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
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
        private System.Windows.Forms.ListBox processBlacklist_listbx;
        private MetroFramework.Controls.MetroButton addProcess;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox process_txtbx;
        private MetroFramework.Controls.MetroButton removeProcess;
        private MetroFramework.Controls.MetroToggle blacklistIsSorted;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.Timer blacklistChecker;
        private MetroFramework.Controls.MetroToggle optimization_checkbx;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel file_hash_lbl;
        private MetroFramework.Controls.MetroButton copyMD5_btm;
        private MetroFramework.Controls.MetroButton compare_btm;
    }
}

