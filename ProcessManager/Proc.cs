using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManager
{
    class Proc
    {
        public static int KillByName(string ProcessName)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process p in processes)
            {
                try
                {
                    p.Kill();
                }
                catch { return 1;}
            }
            return 0;
        }
        public static int KillById(Int32 ProcessID)
        {
            Process process = Process.GetProcessById(ProcessID);
            try
            {
                process.Kill();
            }
            catch { return 1; }
            return 0;
        }
        public static int KillByFile(string pathToFile, out string ProcessName)
        {
            ProcessName = "";
            Process[] allProcesses = Process.GetProcesses();
            foreach (Process p in allProcesses)
            {
                ProcessModuleCollection modules = p.Modules;
                foreach (ProcessModule m in modules)
                {
                    if (m.FileName == pathToFile)
                    {
                        ProcessName = p.ProcessName;
                        p.Kill();
                        return 0;
                    }
                }
            }
            return 1;
        }

        public static bool IsProcessExists(int Pid)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (p.Id == Pid)
                    return true;
            }
            return false;
        }
        public static bool IsProcessExists(string Name)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (p.ProcessName == Name)
                    return true;
            }
            return false;
        }
    }
}
