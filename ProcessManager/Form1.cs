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


namespace ProcessManager
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
        }
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
        DllInjector inj = null;

      //vars
        Process process = new Process();
        public static bool paused = false;
        public static bool exists = false;

      //methods
        private void OpenFileDialogMethod(object sender, EventArgs e)
        {
            openFileDialog.Filter = "exe files | *.exe";   
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile.Text = openFileDialog.FileName;
            }
        }
        private void StartProcess(object sender, EventArgs e)
        {
            if (exists)
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
                    exists = true;
                    if (pauseOnStart.Checked)
                    {
                        SuspendProcess(pid);
                        paused = true;
                    }
                    WriteModulesInListbox1(sender, e);
                    /*file info*/
                    FileInfo fn = new FileInfo(pathToFile.Text);
                    fileName_lbl.Text = "Name: " + fn.Name;
                    size_lbl.Text = "Size: " + fn.Length + " bytes";
                    creationTime_lbl.Text = "Creation time: " + fn.CreationTime;
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
                DateTime date = DateTime.Now;
                string temp = String.Format("[ {0} ]\tUnpausing Process {1}", date.ToString(), pathToFile.Text);
                history_listbx.Items.Add(temp);
            }
            else
            {
                SuspendProcess(process.Id);
                paused = true;
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

      //buttoms etc
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (exists)
                    if (process.HasExited)
                        exists = false;
            }
            catch (Exception ex)
            {
                string ex_ = ex.ToString();
                exists = false;
                paused = false;
                processName_txtbx.Text = "";
                pathToFile.Text = "";
                listBox1.Items.Clear();
                MessageBox.Show("System process");
            }
            if (paused)
            {
                pause.Text = "Resume Process";
                status_txtbx.ForeColor = Color.Yellow;
                status_txtbx.Text = "Paused";
            }
            else
            {
                pause.Text = "Pause Process";
                status_txtbx.ForeColor = Color.Green;
                status_txtbx.Text = "Working";
            }
            if (!exists)
            {
                status_txtbx.ForeColor = Color.Gray;
                status_txtbx.Text = "No process";

                kill_btm.Enabled = false;
                pause.Enabled = false;
                //infoPanel.Visible = false;
                getModules.Enabled = false;
                injectDll_btm.Enabled = false;
                injectDll_private_btm.Enabled = false;
                selectProcess.Enabled = true;
                //process_txtbx
                processName_txtbx.Text = "";
            }
            else
            {
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
            if (help_withId.Checked)
            {
                if (processList.SelectedIndex >= 0)
                {
                    string obj = processList.SelectedItem.ToString();
                    string[] arr = obj.Split('\t');
                    string id = arr[1];
                    processPid_txtbx.Text = id;
                }
            }
            //modules
            try
            {
                ProcessModuleCollection pmc = process.Modules;
                if (listBox1.SelectedIndex >= 0)
                {
                    int index = listBox1.SelectedIndex;
                    pathToModule_lbl.Text = pmc[index].FileName.ToString();
                }
            }
            catch
            {
                pathToModule_lbl.Text = "No info";
            }
            //watermark
            watermark_timer.Interval = watermarkspeed.Value;
            //colors
            history_listbx.BackColor = listBox1.BackColor;
            history_listbx.ForeColor = listBox1.ForeColor;

            processList.BackColor = listBox1.BackColor;
            processList.ForeColor = listBox1.ForeColor;

            symbols_txtbx.BackColor = listBox1.BackColor;
            symbols_txtbx.ForeColor = listBox1.ForeColor;

            processBlacklist_listbx.BackColor = history_listbx.BackColor;
            processBlacklist_listbx.ForeColor = history_listbx.ForeColor;
            //progressbar
            progressBar1.Maximum = numOfFiles;
            progressBar1.Value = numOfFilesChecked;
            //log
            if (log != "")
            {
                log_txtbx.Text = log + ProcessName;
                cancel_btm.Enabled = true;
            }
            else
            {
                cancel_btm.Enabled = false;
            }
            //blacklist
            if (blacklistIsSorted.Checked)
                processBlacklist_listbx.Sorted = true;
            else
                processBlacklist_listbx.Sorted = false;
            string[] processBlackList = new string[processBlacklist_listbx.Items.Count];
            for (int i = 0; i < processBlackList.Length; i++)
            {
                processBlackList[i] = processBlacklist_listbx.Items[i].ToString();

                Process[] p = Process.GetProcessesByName(processBlackList[i]);
                foreach (var proc in p)
                {
                    try
                    {
                        proc.Kill();
                        DateTime date = DateTime.Now;
                        string temp = String.Format("[ {0} ]\tProcess {1} from blacklist killed", date.ToString(), processBlackList[i]);
                        history_listbx.Items.Add(temp);
                    }
                    catch { }
                }
            }
            
        }
        private void start_Click_1(object sender, EventArgs e)
        {
            StartProcess(sender, e);
        }
        private void pause_Click_1(object sender, EventArgs e)
        {
            PauseProcess(sender, e);
        }
        private void getModules_Click_1(object sender, EventArgs e)
        {
            WriteModulesInListbox1(sender, e);
        }
        private void kill_btm_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string temp = String.Format("[ {0} ]\tTrying to kill process {1}", date.ToString(), pathToFile.Text);
            string process_ = pathToFile.Text;
            history_listbx.Items.Add(temp);
            int count = 0;
            while (true)
            {
                try
                {
                    Process[] ps1 = Process.GetProcessesByName(process.ProcessName);
                    foreach (Process p1 in ps1)
                        p1.Kill();

                    process.Kill();
                    pathToFile.Text = "";
                    listBox1.Items.Clear();
                    exists = false;
                    paused = false;
                    temp = String.Format("[ {0} ]\tProcess killed {1}", date.ToString(), process_);
                    history_listbx.Items.Add(temp);
                    break;
                }
                catch { }
                count++;
                if(count > 10)
                {
                    try
                    {
                        Process[] ps1 = Process.GetProcessesByName(process.ProcessName);
                        foreach (Process p1 in ps1)
                            p1.Kill();

                        process.Kill();
                        pathToFile.Text = "";
                        listBox1.Items.Clear();
                        exists = false;
                        paused = false;
                        temp = String.Format("[ {0} ]\tProcess killed {1}", date.ToString(), process_);
                        history_listbx.Items.Add(temp);
                        break;
                    }
                    catch(Exception ex)
                    {
                        temp = String.Format("[ {0} ]\tError while killing process {1}, exception {2}", date.ToString(), process_, ex.ToString());
                        history_listbx.Items.Add(temp);
                        break;
                    }
                }
                Thread.Sleep(100);
            }
            listBox1.Items.Clear();
            processList.Items.Clear();
            Process[] procList = Process.GetProcesses();
            foreach (Process p in procList)
            {
                processList.Items.Add(p.ProcessName + "\t" + p.Id);
                processList.Sorted = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialogMethod(sender, e);
        }
        Random rnd = new Random();
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

            processList.Items.Clear();
            Process[] procList = Process.GetProcesses();
            foreach (Process p in procList)
            {
                processList.Items.Add(p.ProcessName + "\t" + p.Id);
                processList.Sorted = true;
            }
            //settings
            if (Directory.Exists(pathToCfg) && File.Exists(pathToCfg + @"\blacklist.txt"))
            {
                string path = pathToCfg + @"\blacklist.txt";
                string[] linesInBlackList = File.ReadAllLines(path);
                for (int i = 0; i < linesInBlackList.Length; i++)
                {
                    processBlacklist_listbx.Items.Add(linesInBlackList[i]);
                }
            }
            else
                Directory.CreateDirectory(pathToCfg);
        }
        static string[] lines = new string[2];
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
        }
        //process tab
        private void historyRefreshing_Tick(object sender, EventArgs e)
        {
            history_listbx.Refresh();
            history_listbx.BackColor = listBox1.BackColor;
            history_listbx.ForeColor = listBox1.ForeColor;
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
        private void tryToFindModules_Click(object sender, EventArgs e)
        {
            if (exists)
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
                    if (paused)
                    {
                        ResumeProcess(process.Id);
                        Thread.Sleep(275);
                        SuspendProcess(process.Id);
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
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
        private void selectProcess_Click(object sender, EventArgs e)
        {
            try
            {
                process = Process.GetProcessById(Convert.ToInt32(processPid_txtbx.Text));
                exists = true;
                paused = false;
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
        private void unselect_btm_Click(object sender, EventArgs e)
        {
            exists = false;
            paused = false;
            processName_txtbx.Text = "";
            pathToFile.Text = "";
            listBox1.Items.Clear();
        }
        internal class Inject
        {
            // Token: 0x06000004 RID: 4 RVA: 0x0000209C File Offset: 0x0000029C
            private static byte[] CalcBytes(string sToConvert)
            {
                return Encoding.ASCII.GetBytes(sToConvert);
            }

            // Token: 0x06000005 RID: 5 RVA: 0x00002140 File Offset: 0x00000340
            private static bool CRT(Process pToBeInjected, string sDllPath, out string sError, out IntPtr hwnd)
            {
                sError = string.Empty;
                IntPtr intPtr = Inject.WINAPI.OpenProcess(1082u, 1, (uint)pToBeInjected.Id);
                hwnd = intPtr;
                if (intPtr == IntPtr.Zero)
                {
                    return false;
                }
                IntPtr procAddress = Inject.WINAPI.GetProcAddress(Inject.WINAPI.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                if (procAddress == IntPtr.Zero)
                {
                    return false;
                }
                IntPtr intPtr2 = Inject.WINAPI.VirtualAllocEx(intPtr, IntPtr.Zero, (IntPtr)sDllPath.Length, 12288u, 4u);
                if (intPtr2 == IntPtr.Zero && intPtr2 == IntPtr.Zero)
                {
                    return false;
                }
                byte[] array = Inject.CalcBytes(sDllPath);
                IntPtr zero = IntPtr.Zero;
                Inject.WINAPI.WriteProcessMemory(intPtr, intPtr2, array, (uint)array.Length, out zero);
                return Marshal.GetLastWin32Error() == 0 && !(Inject.WINAPI.CreateRemoteThread(intPtr, IntPtr.Zero, IntPtr.Zero, procAddress, intPtr2, 0u, IntPtr.Zero) == IntPtr.Zero);
            }

            // Token: 0x06000006 RID: 6 RVA: 0x00002224 File Offset: 0x00000424
            public static bool DoInject(Process pToBeInjected, string sDllPath, out string sError)
            {
                IntPtr zero = IntPtr.Zero;
                if (!Inject.CRT(pToBeInjected, sDllPath, out sError, out zero))
                {
                    if (zero != IntPtr.Zero)
                    {
                        Inject.WINAPI.CloseHandle(zero);
                    }
                    return false;
                }
                Marshal.GetLastWin32Error();
                return true;
            }

            // Token: 0x02000007 RID: 7
            private static class WINAPI
            {
                // Token: 0x06000014 RID: 20
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern int CloseHandle(IntPtr hObject);

                // Token: 0x06000015 RID: 21
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

                // Token: 0x06000016 RID: 22
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern IntPtr GetModuleHandle(string lpModuleName);

                // Token: 0x06000017 RID: 23
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

                // Token: 0x06000018 RID: 24
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

                // Token: 0x06000019 RID: 25
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

                // Token: 0x0600001A RID: 26
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

                // Token: 0x02000008 RID: 8
                public static class VAE_Enums
                {
                    // Token: 0x02000009 RID: 9
                    public enum AllocationType
                    {
                        // Token: 0x04000007 RID: 7
                        MEM_COMMIT = 4096,
                        // Token: 0x04000008 RID: 8
                        MEM_RESERVE = 8192,
                        // Token: 0x04000009 RID: 9
                        MEM_RESET = 524288
                    }

                    // Token: 0x0200000A RID: 10
                    public enum ProtectionConstants
                    {
                        // Token: 0x0400000B RID: 11
                        PAGE_EXECUTE = 16,
                        // Token: 0x0400000C RID: 12
                        PAGE_EXECUTE_READ = 32,
                        // Token: 0x0400000D RID: 13
                        PAGE_EXECUTE_READWRITE = 4,
                        // Token: 0x0400000E RID: 14
                        PAGE_EXECUTE_WRITECOPY = 8,
                        // Token: 0x0400000F RID: 15
                        PAGE_NOACCESS = 1
                    }
                }
            }
        }
        private void injectDll_private_btm_Click(object sender, EventArgs e)
        {
            string err = "";
            Inject.DoInject(Process.GetProcessById(process.Id), pathToDll_txtbx.Text, out err);
            MessageBox.Show("Dll injected");
        }
        //watermark
        static int step = 1;
        private void watermark_timer_Tick(object sender, EventArgs e)
        {
            WaterMarkStep(step);
            watermark.Refresh();
            step += 1;
            if (step >= 42)
                step = 1;
        }
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
        //delete file
        public static string ProcessName = "";
        public void UnlockFile(string path, out string processName)
        {
            processName = "";
            log = path;
            Process[] procList = Process.GetProcesses();
            int counter = 0;
            foreach (Process p in procList)
            {
                ProcessName = "\t|\t" + p.ProcessName;
                if (stop)
                {
                    log = "";
                    break;
                }
                try
                {
                    ProcessModuleCollection modules = p.Modules;
                    foreach (ProcessModule m in modules)
                    {
                        if (path.ToLower() == m.FileName.ToLower())
                        {
                            processName = p.ProcessName;
                            p.Kill();
                            File.Delete(path);
                            break;
                        }
                    }
                }
                catch { }
                counter++;
            }
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
                File.Delete(path);
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
        }
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
            numOfFilesChecked = 0;
        }
        Thread thread;
        private void unlockDir_btm_Click(object sender, EventArgs e)
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
            numOfFilesChecked = 0;
        }
        public static int numOfFiles = 0;
        public static int numOfFilesChecked = 0;
        public static string path = "";
        public static string log = "";
        private void UnlockDirMethod()
        {
            string path = folderBrowserDialog1.SelectedPath;
            string[] files = Directory.GetFiles(path);
            numOfFiles = files.Length;
            string process = "";
            string[] arrOfProcesses = new string[9999999];
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
                if(delete)
                    File.Delete(files[i]);
                if (process != "")
                {
                    numOfProc += 1;
                    process = "";
                }
                numOfFilesChecked = i + 1;
            }

            if(!delete)
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
                        File.Delete(files[i]);
                    }
                    files = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
                    for (int i = files.Length - 1; i >= 0; i--)
                    {
                        Directory.Delete(files[i]);
                    }
                    Directory.Delete(path);
                    MessageBox.Show(numOfProc + " processes killed. Dir deleted");
                }
                catch { MessageBox.Show(numOfProc + " processes killed"); }
            }
            numOfFilesChecked = 0;
            //arr of processes
        }
        public static bool delete = false;
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
            numOfFilesChecked = 0;
        }
        public static bool stop = false;
        private void cancel_btm_Click(object sender, EventArgs e)
        {
            stop = true;
        }
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

        string pathToCfg = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Process Manager";
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //save cfg
            string[] linesInBlacklist = new string[processBlacklist_listbx.Items.Count];
            for (int i = 0; i < linesInBlacklist.Length; i++)
            {
                linesInBlacklist[i] = processBlacklist_listbx.Items[i].ToString();
            }
            File.WriteAllLines(pathToCfg + "\\blacklist.txt", linesInBlacklist);
        }
    }
}