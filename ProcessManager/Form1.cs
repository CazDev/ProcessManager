using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Reflection;
using System.Resources;

namespace ProcessManager
{
    public partial class Form1 : MetroForm
    {
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
        public enum DllInjectionResult
        {
            DllNotFound,
            GameProcessNotFound,
            InjectionFailed,
            Success
        }
        public sealed class DllInjector
        {
            static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
                IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

            static DllInjector _instance;

            public static DllInjector GetInstance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new DllInjector();
                    }
                    return _instance;
                }
            }

            DllInjector() { }

            public DllInjector(string pathToDll)
            {
            }

            public DllInjectionResult Inject(string sProcName, string sDllPath)
            {
                if (!File.Exists(sDllPath))
                {
                    return DllInjectionResult.DllNotFound;
                }

                uint _procId = 0;

                Process[] _procs = Process.GetProcesses();
                for (int i = 0; i < _procs.Length; i++)
                {
                    if (_procs[i].ProcessName == sProcName)
                    {
                        _procId = (uint)_procs[i].Id;
                        break;
                    }
                }

                if (_procId == 0)
                {
                    return DllInjectionResult.GameProcessNotFound;
                }

                if (!bInject(_procId, sDllPath))
                {
                    return DllInjectionResult.InjectionFailed;
                }

                return DllInjectionResult.Success;
            }

            bool bInject(uint pToBeInjected, string sDllPath)
            {
                IntPtr hndProc = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, pToBeInjected);

                if (hndProc == INTPTR_ZERO)
                {
                    return false;
                }

                IntPtr lpLLAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                if (lpLLAddress == INTPTR_ZERO)
                {
                    return false;
                }

                IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)sDllPath.Length, (0x1000 | 0x2000), 0X40);

                if (lpAddress == INTPTR_ZERO)
                {
                    return false;
                }

                byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);

                if (WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
                {
                    return false;
                }

                if (CreateRemoteThread(hndProc, (IntPtr)null, INTPTR_ZERO, lpLLAddress, lpAddress, 0, (IntPtr)null) == INTPTR_ZERO)
                {
                    return false;
                }

                CloseHandle(hndProc);

                return true;
            }
        }
        private static void SuspendProcess(int pid)
        {
            var process = Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
        }
        public static void ResumeProcess(int pid)
        {
            var process = Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);

                CloseHandle(pOpenThread);
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            log_Changed();
            UpdateColors();
            StatusUpdate();
        }
        DllInjector inj = null;
//end stf

//vars
        Process process = new Process();
        public static bool paused = false;
        public static bool existsProcess = false;
        Random rnd = new Random();
        Thread thread;
        string pathToCfg = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Process Manager";
        static string[] lines = new string[2];
        public static string pathToAutoStart = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + @"\Programs";

//methods
        private void StartProcess(object sender, EventArgs e)
        {
            if (existsProcess)
            {
                process.Kill();
                listBox1.Items.Clear();
            }
            // process = new Process();
            if (pathToFile.Text != "")
            {
                DateTime date = DateTime.Now;
                string temp = String.Format("[ {0} ]\tStarting Process {1}", date.ToString(), pathToFile.Text);
                history_listbx.Items.Add(temp);
                try
                {
                    process.StartInfo.FileName = pathToFile.Text;
                    process.Start();
                    int pid = process.Id;
                    existsProcess = true;
                    StatusUpdate();
                    if (pauseOnStart.Checked)
                    {
                        SuspendProcess(pid);
                        paused = true;
                        StatusUpdate();
                    }
                    WriteModulesInListbox1(sender, e);
                    /*file info*/
                    FileInfo fn = new FileInfo(pathToFile.Text);
                    fileName_lbl.Text = "Name: " + fn.Name;
                    size_lbl.Text = "Size: " + fn.Length + " bytes";
                    creationTime_lbl.Text = "Creation time: " + fn.CreationTime;
                    file_hash_lbl.Text = "MD5: " + Files.GetMD5Hash(pathToFile.Text);
                }
                catch(Exception ex)
                {
                    date = DateTime.Now;
                    temp = String.Format("[ {0} ]\tFailed to start process {1}, exception {2}", date.ToString(), pathToFile.Text, ex.ToString());
                    history_listbx.Items.Add(temp);
                }
            }
        }
        private void PauseProcess(object sender, EventArgs e)
        {
            if(pause.Text == "Resume Process")
            {
                ResumeProcess(process.Id);
                paused = false;
                StatusUpdate();
                DateTime date = DateTime.Now;
                string temp = String.Format("[ {0} ]\tUnpausing Process {1}", date.ToString(), pathToFile.Text);
                history_listbx.Items.Add(temp);
            }
            else
            {
                SuspendProcess(process.Id);
                paused = true;
                StatusUpdate();
                DateTime date = DateTime.Now;
                string temp = String.Format("[ {0} ]\tPausing Process {1}", date.ToString(), pathToFile.Text);
                history_listbx.Items.Add(temp);
            }
        }
        private void WriteModulesInListbox1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int counter = 0;
            while ("ti lox" == "ti lox")
            {
                try
                {
                    ProcessModuleCollection pmc = process.Modules;
                    for (int i = 0; i < pmc.Count; i++)
                    {
                        listBox1.Items.Add(pmc[i].ToString().Substring("system.diagnostics.Modules.Module".Length));
                    }
                    break;
                }
                catch { }
                counter++;
                if (counter >= 10)
                {
                    try
                    {
                        ProcessModuleCollection pmc = process.Modules;
                        listBox1.Items.Add("Fail (" + pmc.Count + " modules)");
                    }
                    catch { listBox1.Items.Add("Fail"); }
                    break;
                }
                Thread.Sleep(100);
            }
        }
        public void FormSizeChanged(bool iconEnabled, FormWindowState formState)
        {
            if (iconEnabled)
            {
                if (formState == FormWindowState.Minimized)
                {
                    icon.Visible = true;
                    ShowInTaskbar = false;
                    icon.BalloonTipText = "I am here";
                    icon.ShowBalloonTip(100);
                }
                else if (formState == FormWindowState.Maximized)
                {
                    icon.Visible = false;
                    this.ShowInTaskbar = true;
                }
            }
            else
            {
                icon.Visible = false;
                ShowInTaskbar = true;
            }
        }
        private void StatusUpdate()
        {
            if (paused)
            {
                pause.Text = "Resume Process";
                status_txtbx.Text = "Paused";
            }
            else
            {
                if (existsProcess)
                {
                    pause.Text = "Pause Process";
                    status_txtbx.Text = "Working";

                    kill_btm.Enabled = true;
                    pause.Enabled = true;
                    // infoPanel.Visible = true;
                    getModules.Enabled = true;
                    injectDll_btm.Enabled = true;
                    injectDll_private_btm.Enabled = true;
                    selectProcess.Enabled = false;
                    /**/
                    name_lbl.Text = "Name: " + process.ProcessName;
                    pid_lbl.Text = "Pid: " + process.Id;
                    DateTime started = process.StartTime;
                    startTime_lbl.Text = "Start time: " + started.ToString("dd.hh.mm.ss");
                    priority_lbl.Text = "Priority: " + process.PriorityClass;
                    //process_txtbx
                    processName_txtbx.Text = process.ProcessName;
                    processPid_txtbx.Text = process.Id.ToString();
                }
                else
                {
                    pause.Text = "Pause Process";

                    listBox1.Items.Clear();
                    name_lbl.Text = "Name:";
                    pid_lbl.Text = "Pid:";
                    startTime_lbl.Text = "Start time:";
                    priority_lbl.Text = "Priority:";

                    status_txtbx.Text = "No process";

                    kill_btm.Enabled = false;
                    pause.Enabled = false;
                    //infoPanel.Visible = false;
                    getModules.Enabled = false;
                    injectDll_btm.Enabled = false;
                    injectDll_private_btm.Enabled = false;
                    selectProcess.Enabled = true;
                    //process_txtbx
                    //processName_txtbx.Text = "";
                }
            }
        }
        private void UpdateColors()
        {
            history_listbx.BackColor = listBox1.BackColor;
            history_listbx.ForeColor = listBox1.ForeColor;

            processList.BackColor = listBox1.BackColor;
            processList.ForeColor = listBox1.ForeColor;

            symbols_txtbx.BackColor = listBox1.BackColor;
            symbols_txtbx.ForeColor = listBox1.ForeColor;

            processBlacklist_listbx.BackColor = history_listbx.BackColor;
            processBlacklist_listbx.ForeColor = history_listbx.ForeColor;

            listbx_whitelist.ForeColor = listBox1.ForeColor;
            listbx_whitelist.BackColor = listBox1.BackColor;

            listbx_killed.ForeColor = listBox1.ForeColor;
            listbx_killed.BackColor = listBox1.BackColor;

            timer_listbx.BackColor = listBox1.BackColor;
            timer_listbx.ForeColor = listBox1.ForeColor;
        }
        private void log_Changed()
        {
            if (log != "")
            {

                log_txtbx.Text = log + ProcessName;
                cancel_btm.Enabled = true;
            }
            else
            {
                cancel_btm.Enabled = false;
            }
        }
        //события
        private void watermarkspeed_Scroll(object sender, ScrollEventArgs e)
        {
            watermark_timer.Interval = watermarkspeed.Value;
        }
        private void blacklistIsSorted_CheckedChanged(object sender, EventArgs e)
        {
            if (blacklistIsSorted.Checked)
                processBlacklist_listbx.Sorted = true;
            else
                processBlacklist_listbx.Sorted = false;
        }
        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (help_withId.Checked)
            {
                if (processList.SelectedIndex >= 0)
                {
                    string obj = processList.SelectedItem.ToString();
                    string[] arr = obj.Split('\t');
                    string id = arr[1];
                    processPid_txtbx.Text = id;
                    try
                    {
                        if (processName_txtbx.Text != Process.GetProcessById(Convert.ToInt32(id)).ProcessName)
                            processName_txtbx.Text = Process.GetProcessById(Convert.ToInt32(id)).ProcessName;
                    }
                    catch { }
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    ProcessModuleCollection pmc = process.Modules;
                    int index = listBox1.SelectedIndex;
                    pathToModule_lbl.Text = pmc[index].FileName.ToString();
                }
            }
            catch
            {
                pathToModule_lbl.Text = "No info";
            }
        }
        private void icon_checkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (icon_checkbx.Checked)
            {
                icon.Visible = true;
            }
            else
            {
                icon.Visible = false;
            }
        }
        //icon
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            FormSizeChanged(icon_checkbx.Checked, WindowState);
        }
        private void icon_MouseClick(object sender, MouseEventArgs e)
        {
            icon.Visible = false;
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
   //end icon
   //timers
        private void blacklistChecker_Tick(object sender, EventArgs e)
        {
            //blacklist
            string[] processBlackList = new string[processBlacklist_listbx.Items.Count];
            Process[] processes = Process.GetProcesses();
            for (int j = 0; j < processBlacklist_listbx.Items.Count; j++)
            {
                processBlackList[j] = processBlacklist_listbx.Items[j].ToString();
                for (int k = 0; k < processes.Length; k++)
                {
                    if (processBlackList[j] == processes[k].ProcessName)
                    {
                        Process[] p = Process.GetProcessesByName(processBlackList[j]);
                        foreach (var proc in p)
                        {
                            try
                            {
                                proc.Kill();
                                DateTime date = DateTime.Now;
                                string temp = String.Format("[ {0} ]\tProcess {1} from blacklist killed", date.ToString(), processBlackList[j]);
                                history_listbx.Items.Add(temp);
                            }
                            catch { }
                        }
                    }
                }
            }
            //end blacklist
            
            if (WindowState != FormWindowState.Minimized)
            {
                progressBar1.Maximum = numOfFiles;
                progressBar1.Value = numOfFilesChecked;
                //design
            }
        }
        private void CheckProcessExists(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized /*its design etc*/)
            {
                if (existsProcess)
                {
                    try
                    {
                        if (existsProcess)
                            if (process.HasExited)
                            {
                                existsProcess = false;
                                StatusUpdate();
                            }
                    }
                    catch (Exception ex)
                    {
                        string ex_ = ex.ToString();
                        existsProcess = false;
                        paused = false;
                        StatusUpdate();
                        //processName_txtbx.Text = "";
                        pathToFile.Text = "";
                        listBox1.Items.Clear();
                        MessageBox.Show("System process");
                    }
                } //check if process here
            }
        }
        private void historyRefreshing_Tick(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                history_listbx.Refresh();
                history_listbx.TopIndex = history_listbx.Items.Count - 1;
                UpdateColors();
                // history_listbx.SelectedIndex = history_listbx.Items.Count - 1;
            }
        }
        private void watermark_timer_Tick(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WaterMarkStep(step);
                watermark.Refresh();
                step += 1;
                if (step >= 42)
                    step = 1;
            }
        }
   //end timers
   //main
        private void start_Click_1(object sender, EventArgs e)
        {
            StartProcess(sender, e);
        }
        private void pause_Click_1(object sender, EventArgs e)
        {
            PauseProcess(sender, e);
        }
        private void compare_btm_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "AnyFiles | *.*";
                FileInfo fn1;
                FileInfo fn2;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fn1 = new FileInfo(openFileDialog.FileName);
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fn2 = new FileInfo(openFileDialog.FileName);
                        if (Files.CompareFilesByHash(fn1, fn2))
                        {
                            MessageBox.Show("That is the same files");
                        }
                        else
                        {
                            MessageBox.Show("Different files\nMD5: " + Files.GetMD5Hash(fn1.FullName) + "\nMD5: " + Files.GetMD5Hash(fn2.FullName));
                        }
                    }
                }
            }
            catch { }
        }
        private void copyMD5_btm_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Files.GetMD5Hash(pathToFile.Text));
            }
            catch { }
        }
        private void cancel_btm_Click(object sender, EventArgs e)
        {
            stop = true;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "exe files | *.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathToFile.Text = openFileDialog.FileName;

                    FileInfo fn = new FileInfo(pathToFile.Text);
                    fileName_lbl.Text = "Name: " + fn.Name;
                    size_lbl.Text = "Size: " + fn.Length + " bytes";
                    creationTime_lbl.Text = "Creation time: " + fn.CreationTime;
                    file_hash_lbl.Text = "MD5: " + Files.GetMD5Hash(pathToFile.Text);
                }
            }
            catch { MessageBox.Show("FileDialog Method error"); }
        }
        //right side
        private void unlock_btm_Click(object sender, EventArgs e)
        {
            string path = "";
            string process = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                UnlockFile(path, out process);
                if(process != "")
                {
                    MessageBox.Show("Process \"" + process + "\" killed");
                }
                else
                {
                    MessageBox.Show("Already unlocked");
                }
            }
            log = "";
            log_Changed();
            numOfFilesChecked = 0;
        }
        private void deleteFile_btm_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "any files | *.*";
            string path = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string procName = "";
                path = openFileDialog.FileName;
                UnlockFile(path, out procName);
                try
                {
                    File.Delete(path);
                }
                catch { }
                if (procName != "")
                {
                    MessageBox.Show("File deleted");
                }
                else
                {
                    MessageBox.Show("process " + procName + " killed. File deleted");
                }
            }
            log = "";
            log_Changed();
        }
        private void unlockDir_btm_Click(object sender, EventArgs e)
        {
            try
            {
                thread = new Thread(UnlockDirMethod);
                thread.IsBackground = true;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    // string path = folderBrowserDialog1.SelectedPath;
                    thread.Start();
                    delete = false;
                }
                log = "";
                log_Changed();
                numOfFilesChecked = 0;
            }
            catch { }
        }
        private void unlockDirAndDel_btm_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(UnlockDirMethod);
            thread.IsBackground = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // string path = folderBrowserDialog1.SelectedPath;
                thread.Start();
                delete = true;
            }
            log = "";
            log_Changed();
            numOfFilesChecked = 0;
        }
        //end right side
   //end main

   //blacklist
        private void addProcess_Click(object sender, EventArgs e)
        {
            if (process_txtbx.Text != "")
            {
                processBlacklist_listbx.Items.Add(process_txtbx.Text);
                process_txtbx.Text = "";
            }
        }
        private void removeProcess_Click(object sender, EventArgs e)
        {
            if(processBlacklist_listbx.SelectedIndex >= 0)
            {
                processBlacklist_listbx.Items.RemoveAt(this.processBlacklist_listbx.SelectedIndex);
            }
        }
   //end blacklist   
   //process tab
        private void selectProcess_Click(object sender, EventArgs e)
        {
            try
            {
                process = Process.GetProcessById(Convert.ToInt32(processPid_txtbx.Text));
                existsProcess = true;
                paused = false;
                StatusUpdate();
                WriteModulesInListbox1(sender, e);

            
                pathToFile.Text = process.MainModule.FileName;
                /*file info*/
                FileInfo fn = new FileInfo(pathToFile.Text);
                fileName_lbl.Text = "Name: " + fn.Name;
                size_lbl.Text = "Size: " + fn.Length + " bytes";
                creationTime_lbl.Text = "Creation time: " + fn.CreationTime;

                DateTime date = DateTime.Now;
                string temp = String.Format("[ {0} ]\tConnected to process {1}", date.ToString(), process.ProcessName);
                history_listbx.Items.Add(temp);

                processPid_txtbx.Text = "";
            }
            catch { }
        }
        private void getModules_Click_1(object sender, EventArgs e)
        {
            WriteModulesInListbox1(sender, e);
        }
        private void kill_btm_Click(object sender, EventArgs e)
        {

            string ProcessName = process.ProcessName;

            int counter = 0;
            while (Proc.IsProcessExists(ProcessName))
            {
                Proc.KillByName(ProcessName);
                if(counter > 10)
                {
                    DateTime date1 = DateTime.Now;
                    string temp1 = String.Format("[ {0} ]\tUnable to kill process {1}", date1.ToString(), ProcessName);
                    history_listbx.Items.Add(temp1);
                }
            }

            DateTime date = DateTime.Now;
            string temp = String.Format("[ {0} ]\tProcess {1} killed", date.ToString(), ProcessName);
            history_listbx.Items.Add(temp);

            listBox1.Items.Clear();
            processList.Items.Clear();
            Process[] procList = Process.GetProcesses();
            foreach (Process p in procList)
            {
                processList.Items.Add(p.ProcessName + "\t" + p.Id);
                processList.Sorted = true;
            }
        }
        private void refreshProcList_Click(object sender, EventArgs e)
        {
            processList.Items.Clear();
            Process[] procList = Process.GetProcesses();
            foreach (Process p in procList)
            {
                processList.Items.Add(p.ProcessName + "\t" + p.Id);
                processList.Sorted = true;
            }
        }
        private void SelectDll_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "dll files | *.dll";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToDll_txtbx.Text = openFileDialog.FileName;
            }
        }
        private void injectDll_Click(object sender, EventArgs e)
        {
            if (pathToDll_txtbx.Text != "" && processName_txtbx.Text != "")
            {
                inj = new DllInjector(pathToDll_txtbx.Text);
                inj.Inject(process.ProcessName, pathToDll_txtbx.Text);
                MessageBox.Show("Dll injected");
            }
        }
        private void injectDll_private_btm_Click(object sender, EventArgs e)
        {
            string err = "";
            Inject.DoInject(Process.GetProcessById(process.Id), pathToDll_txtbx.Text, out err);
            MessageBox.Show("Dll injected");
        }
        private void unselect_btm_Click(object sender, EventArgs e)
        {
            existsProcess = false;
            paused = false;
            StatusUpdate();
            processName_txtbx.Text = "";
            pathToFile.Text = "";
            listBox1.Items.Clear();
        }
   //end process tab
   //timerprocess
        private void metroButton1_Click(object sender, EventArgs e)
        {
            timer_listbx.Items.Add(timerProcessName_textbx.Text + "\t" + "Mins: 0");
            timerProcessName_textbx.Text = "";
        }
        //timer every minute
        private void timerProcess_Tick(object sender, EventArgs e)
        {
            //getting array
            string[] itemsInListbox = new string[timer_listbx.Items.Count];
            for (int i = 0; i < timer_listbx.Items.Count; i++)
            {
                itemsInListbox[i] = timer_listbx.Items[i].ToString();
            }
            //adding minutes(if procExists)
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < itemsInListbox.Length; i++)
            {
                for (int j = 0; j < processes.Length; j++)
                {
                    if (itemsInListbox[i].Split('\t')[0] == processes[j].ProcessName)
                    {
                        int numOfMins = Convert.ToInt32(itemsInListbox[j].Split('\t')[1].Substring(6));
                        numOfMins += 1;
                        itemsInListbox[j] = itemsInListbox[j].Split('\t')[0] + "\t" + "Mins: " + numOfMins;
                    }
                }
            }
            timer_listbx.Items.Clear();
            //writeInListbx
            for (int i = 0; i < itemsInListbox.Length; i++)
            {
                timer_listbx.Items.Add(itemsInListbox[i]);
            }
        }
   //end timerprocess
   //form
        //save cfg
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save blacklist
            string[] linesInBlacklist = new string[processBlacklist_listbx.Items.Count];
            for (int i = 0; i < linesInBlacklist.Length; i++)
            {
                linesInBlacklist[i] = processBlacklist_listbx.Items[i].ToString();
            }
            File.WriteAllLines(pathToCfg + "\\blacklist.txt", linesInBlacklist);
            //save other
            string[] linesOther = new string[7];
            //0)blacklist sorted 1 or 0
            //1)watermarkspeed 
            //2)helper on?
            //3)color index
            //4)theme index
            //5)Minimize
            linesOther[0] = Convert.ToString(Convert.ToInt32(blacklistIsSorted.Checked));
            linesOther[1] = Convert.ToString(watermarkspeed.Value);
            linesOther[2] = Convert.ToString(Convert.ToInt32(help_withId.Checked));
            linesOther[3] = Convert.ToString(colorSwitcher.SelectedIndex);
            linesOther[4] = Convert.ToString(themeSwitcher.SelectedIndex);
            linesOther[5] = Convert.ToString(Convert.ToInt32(minimize_checkbx.Checked));
            linesOther[6] = Convert.ToString(Convert.ToInt32(icon_checkbx.Checked));
            File.WriteAllLines(pathToCfg + "\\other.txt", linesOther);
            //timer
            string[] timerListbx = new string[timer_listbx.Items.Count];
            for (int i = 0; i < timer_listbx.Items.Count; i++)
            {
                timerListbx[i] = timer_listbx.Items[i].ToString();
            }
            File.WriteAllLines(pathToCfg + "\\timer.txt", timerListbx);
        }
        //end save cfg
        private void Form1_Load(object sender, EventArgs e)
        {
            colorSwitcher.SelectedIndex = 11;
            themeSwitcher.SelectedIndex = 1;

            DateTime date = DateTime.Now;
            string temp = String.Format("[ {0} ]\tProgram loaded", date.ToString());
            history_listbx.Items.Add(temp);

            history_listbx.BackColor = listBox1.BackColor;
            history_listbx.ForeColor = listBox1.ForeColor;

            processList.BackColor = listBox1.BackColor;
            processList.ForeColor = listBox1.ForeColor;

            listbx_whitelist.ForeColor = listBox1.ForeColor;
            listbx_whitelist.BackColor = listBox1.BackColor;

            listbx_killed.ForeColor = listBox1.ForeColor;
            listbx_killed.BackColor = listBox1.BackColor;

            processList.Items.Clear();
            Process[] procList = Process.GetProcesses();
            foreach (Process p in procList)
            {
                processList.Items.Add(p.ProcessName + "\t" + p.Id);
                processList.Sorted = true;
            }
            //settings
            if (Directory.Exists(pathToCfg) && File.Exists(pathToCfg + @"\\blacklist.txt") && File.Exists(pathToCfg + @"\\other.txt"))
            {
                string path = pathToCfg + @"\\blacklist.txt";
                string[] linesInBlackList = File.ReadAllLines(path);
                for (int i = 0; i < linesInBlackList.Length; i++)
                {
                    processBlacklist_listbx.Items.Add(linesInBlackList[i]);
                }
                //other
                string[] linesOther = File.ReadAllLines(pathToCfg + "\\other.txt");
                //0)blacklist sorted 1 or 0
                //1)watermarkspeed 
                //2)helper on?
                //3)color index
                //4)theme index
                try
                {
                    if (linesOther[0] == "1")
                        blacklistIsSorted.Checked = true;
                    else
                        blacklistIsSorted.Checked = false;
                    watermarkspeed.Value = Convert.ToInt32(linesOther[1]);
                    if (linesOther[2] == "1")
                        help_withId.Checked = true;
                    else
                        help_withId.Checked = false;
                    colorSwitcher.SelectedIndex = Convert.ToInt32(linesOther[3]);
                    themeSwitcher.SelectedIndex = Convert.ToInt32(linesOther[4]);
                    if (linesOther[5] == "1")
                        minimize_checkbx.Checked = true;
                    else
                        minimize_checkbx.Checked = false;
                    if (linesOther[6] == "1")
                        icon_checkbx.Checked = true;
                    else
                        icon_checkbx.Checked = false;
                    //timer
                   
                    string[] timerListbx = File.ReadAllLines(pathToCfg + "\\timer.txt");
                    for (int i = 0; i < timerListbx.Length; i++)
                    {
                        timer_listbx.Items.Add(timerListbx[i]);
                    }
                }
                catch
                {
                    File.Delete(pathToCfg + "\\other.txt");
                    File.Delete(pathToCfg + "\\timer.txt");
                }
            }
            else
                Directory.CreateDirectory(pathToCfg);
            //autostart
            if (minimize_checkbx.Checked)
                WindowState = FormWindowState.Minimized;
            UpdateColors();
            watermark_timer.Interval = watermarkspeed.Value;
        }
        //theme
        private void colorSwitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (colorSwitcher.Text)
            {
                case "Default":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Default;
                    lines[0] = "0";

                    break;
                case "White":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.White;
                    lines[0] = "1";

                    break;
                case "Black":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Black;
                    lines[0] = "2";

                    break;
                case "Blue":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Blue;
                    lines[0] = "3";

                    break;
                case "Lime":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
                    lines[0] = "4";

                    break;
                case "Orange":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
                    lines[0] = "5";
                    break;
                case "Teal":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Teal;
                    lines[0] = "6";

                    break;
                case "Brown":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Brown;
                    lines[0] = "7";

                    break;
                case "Magenta":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta;
                    lines[0] = "8";

                    break;
                case "Pink":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Pink;
                    lines[0] = "9";

                    break;
                case "Purple":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
                    lines[0] = "10";

                    break;
                case "Red":
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
                    lines[0] = "11";

                    break;
            }
            UpdateColors();
        }
        private void themeSwitcher_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (themeSwitcher.SelectedIndex)
            {
                case 0:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    kill_btm.BackColor = BackColor = Color.FromArgb(255, 255, 255);
                    kill_btm.ForeColor = Color.FromArgb(255, 0, 0);
                    button1.BackColor = BackColor = Color.FromArgb(255, 255, 255);
                    button1.BackColor = Color.FromArgb(0, 0, 0);
                    /**/
                    listBox1.BackColor = Color.FromArgb(255, 255, 255);
                    listBox1.ForeColor = Color.FromArgb(0, 0, 0);

                    lines[1] = "0";
                    break;
                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    kill_btm.BackColor = Color.FromArgb(17, 17, 17);
                    kill_btm.ForeColor = Color.FromArgb(255, 0, 0);
                    button1.BackColor = Color.FromArgb(17, 17, 17);
                    button1.ForeColor = Color.FromArgb(200, 200, 200);
                    /**/
                    listBox1.BackColor = Color.FromArgb(17, 17, 17);
                    listBox1.ForeColor = Color.FromArgb(200, 200, 200);

                    lines[1] = "1";
                    break;
            }
            UpdateColors();
        }
        //end theme
//watermark
        static int step = 1;
        public static int symbolsCounter = 0;
        private void WaterMarkStep(int step)
        {
            switch (step)
            {
                case 1:
                    watermark.Text = "Coded by Tavvi in C#";
                    break;
                case 2:
                    watermark.Text = "oded by Tavvi in C# ";
                    break;
                case 3:
                    watermark.Text = "ded by Tavvi in C#  ";
                    break;
                // i know that is stupid *_*
                case 4:
                    watermark.Text = "ed by Tavvi in C#   ";
                    break;
                case 5:
                    watermark.Text = "d by Tavvi in C#    ";
                    break;
                case 6:
                    watermark.Text = " by Tavvi in C#     ";
                    break;
                case 7:
                    watermark.Text = "by Tavvi in C#      ";
                    break;
                case 8:
                    watermark.Text = "y Tavvi in C#       ";
                    break;
                case 9:
                    watermark.Text = " Tavvi in C#        ";
                    break;
                case 10:
                    watermark.Text = "Tavvi in C#         ";
                    break;
                case 11:
                    watermark.Text = "avvi in C#          ";
                    break;
                case 12:
                    watermark.Text = "vvi in C#           ";
                    break;
                case 13:
                    watermark.Text = "vi in C#            ";
                    break;
                case 14:
                    watermark.Text = "i in C#             ";
                    break;
                case 15:
                    watermark.Text = " in C#              ";
                    break;
                case 16:
                    watermark.Text = "in C#               ";
                    break;
                case 17:
                    watermark.Text = "n C#                ";
                    break;
                case 18:
                    watermark.Text = " C#                 ";
                    break;
                case 19:
                    watermark.Text = "C#                  ";
                    break;
                case 20:
                    watermark.Text = "#                   ";
                    break;
                case 21:
                    watermark.Text = "                    ";
                    break;
                case 22:
                    watermark.Text = "                   C";
                    break;
                case 23:
                    watermark.Text = "                  Co";
                    break;
                case 24:
                    watermark.Text = "                 Cod";
                    break;
                case 25:
                    watermark.Text = "                Code";
                    break;
                case 26:
                    watermark.Text = "               Coded";
                    break;
                case 27:
                    watermark.Text = "              Coded ";
                    break;
                case 28:
                    watermark.Text = "             Coded b";
                    break;
                case 29:
                    watermark.Text = "            Coded by";
                    break;
                case 30:
                    watermark.Text = "           Coded by ";
                    break;
                case 31:
                    watermark.Text = "          Coded by T";
                    break;
                case 32:
                    watermark.Text = "         Coded by Ta";
                    break;
                case 33:
                    watermark.Text = "        Coded by Tav";
                    break;
                case 34:
                    watermark.Text = "       Coded by Tavv";
                    break;
                case 35:
                    watermark.Text = "      Coded by Tavvi";
                    break;
                case 36:
                    watermark.Text = "     Coded by Tavvi ";
                    break;
                case 37:
                    watermark.Text = "    Coded by Tavvi i";
                    break;
                case 38:
                    watermark.Text = "   Coded by Tavvi in";
                    break;
                case 39:
                    watermark.Text = "  Coded by Tavvi in ";
                    break;
                case 40:
                    watermark.Text = " Coded by Tavvi in C";
                    break;
                case 41:
                    watermark.Text = "Coded by Tavvi in C#";
                    step = 0;
                    break;
            }
            if(step % 2 == 0)
            {
                sticks.Text = @"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\";
                if(log == "")
                stop = false;
            }
            else
            {
                sticks.Text = @"/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/";
                if(log == "")
                stop = false;
            }
            string[] chars = symbols_txtbx.Text.Split('\n');
            try
            {
                if (step % 3 == 0)
                {
                    this.Text = chars[symbolsCounter] + "Process Manager" + chars[symbolsCounter];
                    watermark_top.Text = chars[symbolsCounter];
                    symbolsCounter++;
                    if (symbolsCounter >= chars.Length)
                        symbolsCounter = 0;
                }
            }
            catch { log_txtbx.Text = ""; symbolsCounter = 0; }
        }
//end watermark

//delete file
        public static string ProcessName = "";
        public void UnlockFile(string path, out string processName)
        {
            processName = "";
            log = path;
            Proc.KillByFile(path, out processName);
            Thread.Sleep(500);
            log_txtbx.Text = "";
            log = "";
            log_Changed();
        }
        public static int numOfFiles = 0;
        public static int numOfFilesChecked = 0;
        public static string path = "";
        public static string log = "";
        private void UnlockDirMethod()
        {
            try
            {
                string path = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                numOfFiles = files.Length;
                string process = "";
                string[] arrOfProcesses = new string[Process.GetProcesses().Length];
                int counterOfProcesses = 0;
                int numOfProc = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    if (stop)
                    {
                        log = "";
                        break;
                    }
                    if (delete)
                    {
                        try
                        {
                            File.Delete(files[i]);
                            continue;
                        }
                        catch { }
                    }
                    UnlockFile(files[i], out process);
                    arrOfProcesses[counterOfProcesses] = process;
                    counterOfProcesses++;
                    if (delete)
                        try { File.Delete(files[i]); }
                        catch { }
                    if (process != "")
                    {
                        numOfProc += 1;
                        process = "";
                    }
                    numOfFilesChecked = i + 1;
                }

                if (!delete)
                    MessageBox.Show(numOfProc + " processes killed");
                for (int j = 0; j < 50; j++)
                {
                    try
                    {
                        progressBar1.Value = 0;
                        break;
                    }
                    catch { }
                    Thread.Sleep(50);
                }
                if (delete)
                {
                    try
                    {
                        files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                        for (int i = 0; i < files.Length; i++)
                        {
                            try
                            {
                                File.Delete(files[i]);
                            }
                            catch { }
                        }
                        files = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                        for (int i = files.Length - 1; i >= 0; i--)
                        {
                            try
                            {
                                Directory.Delete(files[i]);
                            }
                            catch { }
                        }
                        Directory.Delete(path);
                        MessageBox.Show(numOfProc + " processes killed. Dir deleted");
                    }
                    catch { MessageBox.Show(numOfProc + " processes killed"); }
                }
                numOfFilesChecked = 0;
                log_txtbx.Text = "";
                //arr of processes
            }
            catch { }
            log = "";
            log_Changed();
        }
        public static bool delete = false;
        public static bool stop = false;
        private void delete_processTimer_Click(object sender, EventArgs e)
        {
            if (timer_listbx.SelectedIndex >= 0)
            {
                timer_listbx.Items.RemoveAt(timer_listbx.SelectedIndex);
            }
        }
 //autostart
        private void autostart_btm_Click(object sender, EventArgs e)
        {
            if (autostart_btm.Text == "Add to autostart")
            {
                if (Autorun(true, Assembly.GetExecutingAssembly().Location))
                {
                    MessageBox.Show("Sucessfully added to autostart");
                }
                else
                    MessageBox.Show("Failed to add to autostart");
            }
            else
            {
                Autorun(false, Assembly.GetExecutingAssembly().Location);
            }
        }
        public bool Autorun(bool boolIfAdd, string ExePath)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("software\\microsoft\\windows\\currentversion\\run\\");
                if (boolIfAdd)//add
                {
                    reg.SetValue("ProcessManager", ExePath);
                }
                else//remove
                {
                    reg.DeleteValue("ProcessManager");
                }
                reg.Flush();
                reg.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        private void removeFromAutostart_btm_Click(object sender, EventArgs e)
        {
            if (Autorun(false, Assembly.GetExecutingAssembly().Location))
                MessageBox.Show("Removed from autostart");
            else
                MessageBox.Show("Failed to remove from autostart");
        }
        // safe mode
        private void btn_add_Click(object sender, EventArgs e)
        {
            if(txtbx_ProcessName.Text != "")
            {
                listbx_whitelist.Items.Add(txtbx_ProcessName.Text);
                txtbx_ProcessName.Text = "";
            }
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            string name = "";
            if(listbx_whitelist.SelectedIndex >= 0)
            {
                name = listbx_whitelist.Items[listbx_whitelist.SelectedIndex].ToString();
                listbx_whitelist.Items.RemoveAt(listbx_whitelist.SelectedIndex);
            }
            while (true)
            {
                bool ok = true;
                for (int i = 0; i < listbx_whitelist.Items.Count; i++)
                {
                    if (listbx_whitelist.Items[i].ToString() == name)
                    {
                        listbx_whitelist.Items.RemoveAt(i);
                        ok = false;
                        break;
                    }
                    else
                        ok = true;
                }
                if (ok)
                    break;
            }
        }
        private void checkbx_safemode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_safemode.Checked)
            {
                Process[] processes = Process.GetProcesses();
                List<Process> processWithoutDoubles = new List<Process>();
                for (int i = 0; i < processes.Length; i++)
                {
                    bool add = true;
                    for (int j = 0; j < processWithoutDoubles.Count; j++)
                    {
                        if (processes[i].ProcessName == processWithoutDoubles[j].ProcessName)
                        {
                            add = false;
                            break;
                        }
                        else
                            add = true;
                    }
                    if (add)
                        processWithoutDoubles.Add(processes[i]);
                }
                for (int i = 0; i < processWithoutDoubles.Count; i++)
                {
                    listbx_whitelist.Items.Add(processWithoutDoubles[i].ProcessName);
                }
            }
            else
            {
                listbx_whitelist.Items.Clear();
                listbx_killed.Items.Clear();
                txtbx_procName.Text = "";
                txtbx_pathtofile.Text = "";
            }
        }
        private void SafeModeChecker_Tick(object sender, EventArgs e)
        {
            listbx_whitelist.ForeColor = listBox1.ForeColor;
            listbx_whitelist.BackColor = listBox1.BackColor;

            listbx_killed.ForeColor = listBox1.ForeColor;
            listbx_killed.BackColor = listBox1.BackColor;
            if (checkbx_safemode.Checked)
            {
                List<string> whiteList = new List<string>();
                for (int i = 0; i < listbx_whitelist.Items.Count; i++)
                {
                    whiteList.Add(listbx_whitelist.Items[i].ToString());
                }

                Process[] prces = Process.GetProcesses();
                List<string> startedProcesses = new List<string>();
                for (int i = 0; i < prces.Length; i++)
                {
                    startedProcesses.Add(prces[i].ProcessName);
                }

                for (int i = 0; i < startedProcesses.Count; i++)
                {
                    bool kill = true;
                    for (int j = 0; j < whiteList.Count; j++)
                    {
                        if (startedProcesses[i] == whiteList[j])
                        {
                            kill = false;
                            break;
                        }
                        else
                        {
                            kill = true;
                        }
                    }
                    if (kill)
                    {
                        Process[] proc = Process.GetProcessesByName(startedProcesses[i]);
                        for (int k = 0; k < proc.Length; k++)
                        {
                            try
                            {
                                listbx_killed.Items.Add($"{proc[k].ProcessName} % {proc[k].MainModule.FileName}");
                                //remove doubles from whitelist
                                String[] processes;
                                List<string> prs = new List<string>();
                                for (int l = 0; l < listbx_whitelist.Items.Count; l++)
                                {
                                    prs.Add(listbx_whitelist.Items[l].ToString());
                                }
                                processes = prs.ToArray();
                                List<string> processWithoutDoubles = new List<string>();
                                for (int s = 0; s < processes.Length; s++)
                                {
                                    bool add = true;
                                    for (int j = 0; j < processWithoutDoubles.Count; j++)
                                    {
                                        if (processes[s] == processWithoutDoubles[j])
                                        {
                                            add = false;
                                            break;
                                        }
                                        else
                                            add = true;
                                    }
                                    if (add)
                                        processWithoutDoubles.Add(processes[s]);
                                }
                                listbx_whitelist.Items.Clear();
                                for (int z = 0; z < processWithoutDoubles.Count; z++)
                                {
                                    listbx_whitelist.Items.Add(processWithoutDoubles[z]);
                                }
                                //Doubles removed from whitelist
                                //remove doubles from killed prcs list bx

                                RemoveDoublesfromKilled_listbx(prs, processWithoutDoubles);

                                //removed

                                if (!checkbx_spyOnly.Checked)
                                {
                                    proc[k].Kill();
                                }
                                else
                                    listbx_whitelist.Items.Add(proc[k].ProcessName);
                            }
                            catch { }
                        }                       
                    }
                    //one more if xD
                    if (kill)
                    {
                        
                    }
                }
            }
        }

        private void RemoveDoublesfromKilled_listbx(List<string> prs, List<string> processWithoutDoubles)
        {
            string[] processes;
            List<string> _processes = new List<string>();
            for (int l = 0; l < listbx_killed.Items.Count; l++)
            {
                _processes.Add(listbx_killed.Items[l].ToString());
            }
            processes = _processes.ToArray();
            List<string> _processWithoutDoubles = new List<string>();
            for (int k = 0; k < processes.Length; k++)
            {
                bool add = true;
                for (int p = 0; p < _processWithoutDoubles.Count; p++)
                {
                    if (processes[k] == _processWithoutDoubles[p])
                    {
                        add = false;
                        break;
                    }
                    else
                        add = true;
                }
                if (add)
                    _processWithoutDoubles.Add(processes[k]);
            }
            listbx_killed.Items.Clear();
            for (int z = 0; z < _processWithoutDoubles.Count; z++)
            {
                listbx_killed.Items.Add(_processWithoutDoubles[z]);
            }
        }

        private void listbx_killed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbx_killed.SelectedIndex >= 0)
            {
                txtbx_procName.Text = listbx_killed.Items[listbx_killed.SelectedIndex].ToString().Split('%')[0];
                txtbx_pathtofile.Text = listbx_killed.Items[listbx_killed.SelectedIndex].ToString().Split('%')[1];
            }
            else
            {
                txtbx_procName.Text = "";
                txtbx_pathtofile.Text = "";
            }
        }
    }
}