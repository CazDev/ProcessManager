using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class Form1 : MetroForm
    {
        #region Suspend&Resume process
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
            UpdateColors();
            StatusUpdate();
        }
        DllInjector inj = null;
        #endregion
        #region vars
        Process process = new Process();
        public static bool paused = false;
        public static bool existsProcess = false;
        Random rnd = new Random();
        Thread thread;
        string pathToCfg = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Process Manager";
        static string[] lines = new string[2];
        public static bool PassworldEntered = false;
        public static string passworld;
        public static string pathToAutoStart = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + @"\Programs";
        static int step = 1;
        public static int symbolsCounter = 0;
        public static string ProcessName = "";
        public static int numOfFiles = 0;
        public static int numOfFilesChecked = 0;
        public static string path = "";
        public static bool delete = false;
        public static bool stop = false;
        public static bool FileSystemWatcherEnabled = false;
        #endregion
        #region methods
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
                catch (Exception ex)
                {
                    date = DateTime.Now;
                    temp = String.Format("[ {0} ]\tFailed to start process {1}, exception {2}", date.ToString(), pathToFile.Text, ex.ToString());
                    history_listbx.Items.Add(temp);
                }
            }
        }
        private void PauseProcess(object sender, EventArgs e)
        {
            if (pause.Text == "Resume Process")
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

            listbx_processBlacklist.BackColor = history_listbx.BackColor;
            listbx_processBlacklist.ForeColor = history_listbx.ForeColor;

            listbx_whitelist.ForeColor = listBox1.ForeColor;
            listbx_whitelist.BackColor = listBox1.BackColor;

            listbx_killed.ForeColor = listBox1.ForeColor;
            listbx_killed.BackColor = listBox1.BackColor;

            listbx_FileWatcher.BackColor = listBox1.BackColor;
            listbx_FileWatcher.ForeColor = listBox1.ForeColor;

            pictureBox1.BackColor = listBox1.BackColor;

            pictureBox1.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox2.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox3.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox4.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox5.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox6.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox7.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox8.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox9.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox10.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
            pictureBox11.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);

        }
        public static string MD5HashString(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public void ShowInfoDialog(string text, string caption)
        {
            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                InfoDialog infoDialog = new InfoDialog(text, caption, BackColorTheme.DARK);
                infoDialog.ShowDialog();
            }
            else
            {
                InfoDialog infoDialog = new InfoDialog(text, caption, BackColorTheme.LIGHT);
                infoDialog.ShowDialog();
            }
        }
        public BackColorTheme GetTheme()
        {
            if (metroStyleManager1.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                return BackColorTheme.DARK;
            }
            else
            {
                return BackColorTheme.LIGHT;
            }
        }
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
            if (step % 2 == 0)
            {
                sticks.Text = @"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\";
            }
            else
            {
                sticks.Text = @"/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/";
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
        private void UnlockDirMethod()
        {
            stop = false;
            cancel_btm.Invoke(new MethodInvoker(delegate
            {
                cancel_btm.Enabled = true;
            }));
            string path = folderBrowserDialog1.SelectedPath;
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            numOfFiles = files.Length;
            List<string> FilesWasntDeleted = new List<string>();
            List<string> ProcessKilled = new List<string>();
            string process = "";
            int numOfProc = 0;
            for (int i = 0; i < files.Length; i++)
            {
                lbl_ProgessInfo.Invoke(new MethodInvoker(delegate
                {
                    lbl_ProgessInfo.Text = $"{numOfFilesChecked} / {numOfFiles}";
                }));
                log_txtbx.Invoke(new MethodInvoker(delegate
                {
                    log_txtbx.Text = files[i];
                }));
                progressBar1.Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Maximum = numOfFiles;
                    progressBar1.Value = numOfFilesChecked;
                }));

                if (stop)
                    break;
                
                if (File.Exists(files[i]))
                {
                    if (delete)
                    {
                        try
                        {
                            File.Delete(files[i]);
                            numOfFilesChecked += 1;
                            continue;
                        }
                        catch
                        {
                            UnlockFile(files[i], out process);
                            try { File.Delete(files[i]); numOfFilesChecked += 1;}
                            catch { FilesWasntDeleted.Add(files[i]); }
                            if (process != "")
                            {
                                numOfProc += 1;
                                ProcessKilled.Add(process);
                                process = "";
                            }
                        }
                    }
                }
                numOfFilesChecked = i + 1;
            }
          
            string[] directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            int dirLength = directories.Length;
            for (int i = directories.Length - 1; i != -1; i--)
            {
                try
                {
                    Directory.Delete(directories[i]);
                }
                catch { }
                lbl_ProgessInfo.Invoke(new MethodInvoker(delegate
                {
                    lbl_ProgessInfo.Text = $"Deleting directories {dirLength - i}/{dirLength}";
                }));
                log_txtbx.Invoke(new MethodInvoker(delegate
                {
                    log_txtbx.Text = $"{directories[i]}";
                }));
            }
            //get strings
            string ProcessKilled_string = "";
            for (int i = 0; i < ProcessKilled.Count; i++)
            {
                ProcessKilled_string += $"{ProcessKilled[i]}\n";
            }
            String filesWasntDeleted_string = "";
            for (int i = 0; i < FilesWasntDeleted.Count; i++)
            {
                filesWasntDeleted_string += $"{FilesWasntDeleted[i]}\n";
            }
            //
            if (!delete)
                ShowInfoDialog(numOfProc + " process(es) killed. Process killed:\n" + ProcessKilled_string, "");
            if (delete)
            {
                try
                {
                    Directory.Delete(path);
                }
                catch { }
                if (FilesWasntDeleted.Count == 0)
                    ShowInfoDialog(numOfProc + " process(es) killed:\n" + ProcessKilled_string, "");
                else
                    ShowInfoDialog(numOfProc + " process(es) killed. Dir was not deleted. " + FilesWasntDeleted.Count + " files wasnt deleted:\n" + filesWasntDeleted_string, "");
            }

            numOfFilesChecked = 0;
            log_txtbx.Invoke(new MethodInvoker(delegate
            {
                log_txtbx.Text = "";
            }));
            cancel_btm.Invoke(new MethodInvoker(delegate
            {
                cancel_btm.Enabled = false;
            }));
            numOfFiles = 0;
            numOfFilesChecked = 0;
            lbl_ProgessInfo.Invoke(new MethodInvoker(delegate
            {
                lbl_ProgessInfo.Text = $"{numOfFilesChecked} / {numOfFiles}";
            }));
            progressBar1.Invoke(new MethodInvoker(delegate
            {
                progressBar1.Maximum = numOfFiles;
                progressBar1.Value = numOfFilesChecked;
            }));
            log_txtbx.Invoke(new MethodInvoker(delegate
            {
                log_txtbx.Text = "";
            }));
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
            }
            catch (Exception ex)
            {
                ShowInfoDialog(ex.ToString(), "");
                return false;
            }
            return true;
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
        public int[] GetForeColorRGB()
        {
            int[] colors;
            switch (themeSwitcher.SelectedIndex)
            {
                case 1:
                    colors = new Int32[] { 17, 17, 17 };
                    break;
                case 0:
                    colors = new Int32[] { 255, 255, 255 };
                    break;
                default:
                    colors = new Int32[] { 255, 255, 255 };
                    break;
            }
            return colors;
        }
        public int[] GetSwicherRGBColor()
        {
            int[] colors;
            switch (colorSwitcher.Text)
            {
                case "Default":
                    colors = new Int32[] { 0, 174, 219 };
                    break;
                case "White":
                    colors = new Int32[] { 255, 255, 255 };
                    break;
                case "Black":
                    colors = new Int32[] { 0, 0, 0 };
                    break;
                case "Blue":
                    colors = new Int32[] { 0, 174, 219 };
                    break;
                case "Lime":
                    colors = new Int32[] { 142, 188, 0 };
                    break;
                case "Orange":
                    colors = new Int32[] { 0, 174, 219 };
                    break;
                case "Teal":
                    colors = new Int32[] { 0, 170, 173 };
                    break;
                case "Brown":
                    colors = new Int32[] { 165, 81, 0 };
                    break;
                case "Magenta":
                    colors = new Int32[] { 255, 0, 148 };
                    break;
                case "Pink":
                    colors = new Int32[] { 231, 113, 189 };
                    break;
                case "Purple":
                    colors = new Int32[] { 124, 65, 153 };
                    break;
                case "Red":
                    colors = new Int32[] { 209, 17, 65 };
                    break;
                default:
                    colors = new Int32[] { 17, 17, 17 };
                    break;
            }
            return colors;
        }
        private void CheckForUpdates()
        {
            progressBar_Update.Invoke(new MethodInvoker(delegate
            {
                progressBar_Update.Maximum = 4;
                progressBar_Update.Value = 0;
                WebClient wc = new WebClient();
                wc.Headers["User-Agent"] = "Mozilla/5.0";
                string fileName = "";
                progressBar_Update.Value = 1;
                for (int i = 1; ; i++)
                {
                    if (!File.Exists($"ProcessManager_Updated {i}.exe"))
                    {
                        fileName = $"ProcessManager_Updated {i}.exe";
                        break;
                    }
                }
                progressBar_Update.Value = 2;
                wc.DownloadFile("https://github.com/tavvi1337/ProcessManager/raw/master/Process%20Manager.exe", fileName);
                progressBar_Update.Value = 3;
                if (Files.GetMD5Hash(fileName) == Files.GetMD5Hash(Assembly.GetExecutingAssembly().Location))
                {
                    File.Delete(fileName);
                    ShowInfoDialog("You already use latest verion", "");
                }
                else
                {
                    ShowInfoDialog($"New version saved to {Assembly.GetExecutingAssembly().Location}\\{fileName}", "");
                }
                progressBar_Update.Value = 4;
                progressBar_Update.Value = 0;
            }));
        }
        #endregion
        #region Timers
        private void blacklistChecker_Tick(object sender, EventArgs e)
        {
            if (checkbx_blacklistEnabled.Checked)
            {
                string[] processBlackList = new string[listbx_processBlacklist.Items.Count];
                Process[] processes = Process.GetProcesses();
                for (int j = 0; j < listbx_processBlacklist.Items.Count; j++)
                {
                    processBlackList[j] = listbx_processBlacklist.Items[j].ToString();
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
                        ShowInfoDialog("System process", "");
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
        #endregion
        #region Events
        private void watermarkspeed_Scroll(object sender, ScrollEventArgs e)
        {
            watermark_timer.Interval = watermarkspeed.Value;
        }
        private void blacklistIsSorted_CheckedChanged(object sender, EventArgs e)
        {
            if (blacklistIsSorted.Checked)
                listbx_processBlacklist.Sorted = true;
            else
                listbx_processBlacklist.Sorted = false;
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
                            ShowInfoDialog("That is the same files. Hash:\n" + Files.GetMD5Hash(fn1.FullName), "");
                        }
                        else
                        {
                            ShowInfoDialog("Different files\nMD5: " + Files.GetMD5Hash(fn1.FullName) + "\nMD5: " + Files.GetMD5Hash(fn2.FullName), "");
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
                    btn_addToAutostart.Enabled = true;
                    btn_removeFromAutostart.Enabled = true;
                }
            }
            catch
            {
                ShowInfoDialog("FileDialog Method error", "");
            }
        }
        private void unlock_btm_Click(object sender, EventArgs e)
        {
            string path = "";
            string process = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                UnlockFile(path, out process);
                if (process != "")
                {
                    ShowInfoDialog("Process \"" + process + "\" killed", "");
                }
                else
                {
                    ShowInfoDialog("Already unlocked", "");
                }
            }
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
                    ShowInfoDialog("File deleted", "");
                }
                else
                {
                    ShowInfoDialog("Process " + procName + " killed. File deleted", "");
                }
            }
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
        }
        private void addProcess_Click(object sender, EventArgs e)
        {
            if (process_txtbx.Text != "")
            {
                bool alreadyExists = false;
                string process_string = process_txtbx.Text;
                for (int i = 0; i < listbx_processBlacklist.Items.Count; i++)
                {
                    if (process_string == listbx_processBlacklist.Items[i].ToString())
                    {
                        alreadyExists = true;
                        break;
                    }
                }
                if (!alreadyExists)
                {
                    listbx_processBlacklist.Items.Add(process_txtbx.Text);
                    process_txtbx.Text = "";
                }
                else
                {
                    ShowInfoDialog("Process already exists", "");
                }
            }
        }
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
                if (counter > 10)
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
                ShowInfoDialog("Dll injected", "");
            }
        }
        private void injectDll_private_btm_Click(object sender, EventArgs e)
        {
            string err = "";
            Inject.DoInject(Process.GetProcessById(process.Id), pathToDll_txtbx.Text, out err);
            ShowInfoDialog("Dll injected", "");
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
        private void removeProcess_Click(object sender, EventArgs e)
        {
            if (listbx_processBlacklist.SelectedIndex >= 0)
            {
                listbx_processBlacklist.Items.RemoveAt(this.listbx_processBlacklist.SelectedIndex);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save blacklist
            string[] linesInBlacklist = new string[listbx_processBlacklist.Items.Count];
            for (int i = 0; i < linesInBlacklist.Length; i++)
            {
                linesInBlacklist[i] = listbx_processBlacklist.Items[i].ToString();
            }
            File.WriteAllLines(pathToCfg + "\\blacklist.txt", linesInBlacklist);
            //save other
            string[] linesOther = new string[8];
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
            linesOther[7] = Convert.ToString(Convert.ToInt32(checkbx_blacklistEnabled.Checked));
            File.WriteAllLines(pathToCfg + "\\other.txt", linesOther);
            //timer
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            colorSwitcher.SelectedIndex = 11;
            themeSwitcher.SelectedIndex = 1;

            DateTime date = DateTime.Now;
            string temp = String.Format("[ {0} ]\tProgram loaded", date.ToString());
            history_listbx.Items.Add(temp);

            btn_addToAutostart.Enabled = false;
            btn_removeFromAutostart.Enabled = false;

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
                    listbx_processBlacklist.Items.Add(linesInBlackList[i]);
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
                    //
                    if (linesOther[2] == "1")
                        help_withId.Checked = true;
                    else
                        help_withId.Checked = false;
                    //
                    if (linesOther[5] == "1")
                        minimize_checkbx.Checked = true;
                    else
                        minimize_checkbx.Checked = false;
                    //
                    if (linesOther[6] == "1")
                        icon_checkbx.Checked = true;
                    else
                        icon_checkbx.Checked = false;
                    //
                    if (linesOther[7] == "1")
                        checkbx_blacklistEnabled.Checked = true;
                    else
                        checkbx_blacklistEnabled.Checked = false;
                    //
                    watermarkspeed.Value = Convert.ToInt32(linesOther[1]);
                    colorSwitcher.SelectedIndex = Convert.ToInt32(linesOther[3]);
                    themeSwitcher.SelectedIndex = Convert.ToInt32(linesOther[4]);
                }
                catch
                {
                    if (MessageBox.Show("Config was loaded incorrectly. Do you want to write it again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(pathToCfg + "\\other.txt");
                    }
                }
            }
            else
                Directory.CreateDirectory(pathToCfg);
            //autostart
            if (minimize_checkbx.Checked)
                WindowState = FormWindowState.Minimized;
            UpdateColors();
            watermark_timer.Interval = watermarkspeed.Value;
            txtbx_file_path.Text = "C:\\";
            //password enter
            if (!File.Exists(pathToCfg + "\\wut.txt"))
            {
                if (!File.Exists(pathToCfg + "\\ok.txt"))
                {
                    if (MessageBox.Show("Do you want to set passworld?", "Process Manager", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PasswordEnter enter = new PasswordEnter(GetTheme());
                        enter.ShowDialog();
                        if (PassworldEntered)
                        {
                            File.WriteAllText(pathToCfg + "\\wut.txt", MD5HashString(passworld));
                        }
                        else { }
                        //stf
                    }
                    else
                        File.WriteAllText(pathToCfg + "\\ok.txt", "");
                }
                else
                {
                    btn_deletePass.Enabled = false;
                    btn_setpassword.Enabled = true;
                }
            }
            else
            {
                PasswordConfirm enter = new PasswordConfirm(GetTheme());
                enter.ShowDialog();
                if (enter.PasswordEntered)
                {
                    string md5 = File.ReadAllText(pathToCfg + "\\wut.txt");
                    string enteredMD5 = MD5HashString(passworld);
                    if (!(md5 == enteredMD5))
                    {
                        ShowInfoDialog("Nice try", "");
                        Environment.Exit(1);
                    }
                }
                else { Environment.Exit(1); }
            }
            if (File.Exists(pathToCfg + "\\wut.txt"))
            {
                btn_deletePass.Enabled = true;
                btn_setpassword.Enabled = false;
            }
            else
            {
                btn_deletePass.Enabled = false;
                btn_setpassword.Enabled = true;
            }
        }
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
        private void autostart_btm_Click(object sender, EventArgs e)
        {
            if (autostart_btm.Text == "Add to autostart")
            {
                if (Autorun(true, Assembly.GetExecutingAssembly().Location))
                {
                    ShowInfoDialog("Sucessfully added to autostart", "");
                }
                else
                    ShowInfoDialog("Failed to add to autostart", "");
            }
            else
            {
                Autorun(false, Assembly.GetExecutingAssembly().Location);
            }
        }
        public void UnlockFile(string path, out string processName)
        {
            processName = "";
            Proc.KillByFile(path, out processName);
            log_txtbx.Invoke(new MethodInvoker(delegate
            {
                log_txtbx.Text = path;
            }));
        }
        private void removeFromAutostart_btm_Click(object sender, EventArgs e)
        {
            if (Autorun(false, Assembly.GetExecutingAssembly().Location))
                ShowInfoDialog("Removed from autostart", "");
            else
                ShowInfoDialog("Failed to remove from autostart", "");
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txtbx_ProcessName.Text != "")
            {
                listbx_whitelist.Items.Add(txtbx_ProcessName.Text);
                txtbx_ProcessName.Text = "";
            }
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            string name = "";
            if (listbx_whitelist.SelectedIndex >= 0)
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
        private void ntn_clearListbx_killed_Click(object sender, EventArgs e)
        {
            listbx_killed.Items.Clear();
            txtbx_procName.Text = "";
            txtbx_pathtofile.Text = "";
        }
        private void btn_deletePass_Click(object sender, EventArgs e)
        {
            string md5 = File.ReadAllText(pathToCfg + "\\wut.txt");
            PasswordConfirm enter = new PasswordConfirm(GetTheme());
            enter.ShowDialog();
            if (enter.PasswordEntered)
            {
                string enteredMD5 = MD5HashString(passworld);
                if (md5 == enteredMD5)
                {
                    ShowInfoDialog("Passworld deleted", "");
                    string temp = "";
                    Proc.KillByFile(pathToCfg + "\\wut.txt", out temp);
                    File.Delete(pathToCfg + "\\wut.txt");
                    btn_deletePass.Enabled = false;
                    btn_setpassword.Enabled = true;
                }
                else
                {
                    ShowInfoDialog("Password is not correct", "");
                }
            }
            else { }
        }
        private void btn_setpassword_Click(object sender, EventArgs e)
        {
            PassworldEntered = false;
            PasswordEnter enter = new PasswordEnter(GetTheme());
            enter.ShowDialog();
            if (PassworldEntered)
            {
                File.WriteAllText(pathToCfg + "\\wut.txt", MD5HashString(passworld));
                ShowInfoDialog("Password created", "");
                btn_deletePass.Enabled = true;
                btn_setpassword.Enabled = false;
                try
                {
                    File.Delete(pathToCfg + "\\ok.txt");
                }
                catch { }
            }
            else { }
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox9.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox10.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox11.BackColor = Color.FromArgb(GetSwicherRGBColor()[0], GetSwicherRGBColor()[1], GetSwicherRGBColor()[2]);
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.FromArgb(GetForeColorRGB()[0], GetForeColorRGB()[1], GetForeColorRGB()[2]);
        }
        private void btn_addToAutostart_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("software\\microsoft\\windows\\currentversion\\run\\");
                string name = pathToFile.Text.Split('\\')[pathToFile.Text.Split('\\').Length - 1];
                reg.SetValue(name, pathToFile.Text);
                reg.Flush();
                reg.Close();
                ShowInfoDialog("Added to auto start", "");
            }
            catch { ShowInfoDialog("Error", ""); }
        }
        private void btn_removeFromAutostart_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("software\\microsoft\\windows\\currentversion\\run\\");
                string name = pathToFile.Text.Split('\\')[pathToFile.Text.Split('\\').Length - 1];
                reg.DeleteValue(name);
                reg.Flush();
                reg.Close();
                ShowInfoDialog("Removed from auto start", "");
            }
            catch { ShowInfoDialog("Registry key not found", ""); }
        }
        private void btn_file_start_Click(object sender, EventArgs e)
        {
            if (btn_file_start.Text == "Start")
            {
                btn_file_start.Text = "Stop";
                FileSystemWatcherEnabled = true;
                listbx_FileWatcher.Items.Clear();
                fileSystemWatcher.Filter = txtbx_file_filter.Text;
                fileSystemWatcher.Path = txtbx_file_path.Text;

                txtbx_file_filter.Enabled = false;
                txtbx_file_path.Enabled = false;
                btn_file_selectDir.Enabled = false;
            }
            else
            {
                btn_file_start.Text = "Start";
                FileSystemWatcherEnabled = false;
                txtbx_file_filter.Enabled = true;
                txtbx_file_path.Enabled = true;
                btn_file_selectDir.Enabled = true;
            }
        }
        private void btn_file_selectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbx_file_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (FileSystemWatcherEnabled)
            {
                listbx_FileWatcher.Items.Add("Modified\t" + e.FullPath);
                listbx_FileWatcher.SelectedIndex = listbx_FileWatcher.Items.Count - 1;
            }
        }
        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (FileSystemWatcherEnabled)
            {
                listbx_FileWatcher.Items.Add("Created\t" + e.FullPath);
                listbx_FileWatcher.SelectedIndex = listbx_FileWatcher.Items.Count - 1;
            }
        }
        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (FileSystemWatcherEnabled)
            {
                listbx_FileWatcher.Items.Add("Deleted\t" + e.FullPath);
                listbx_FileWatcher.SelectedIndex = listbx_FileWatcher.Items.Count - 1;
            }
        }
        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (FileSystemWatcherEnabled)
            {
                listbx_FileWatcher.Items.Add("Renamed\t" + e.FullPath);
                listbx_FileWatcher.SelectedIndex = listbx_FileWatcher.Items.Count - 1;
            }
        }
        private void listbx_FileWatcher_DoubleClick(object sender, EventArgs e)
        {
            string fullname = listbx_FileWatcher.Items[listbx_FileWatcher.SelectedIndex].ToString().Split('\t')[1];
            ManageFile mf = new ManageFile(fullname);
            mf.Show();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CheckForUpdates);
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion
    }
}