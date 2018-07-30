using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessManager
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Program.PriorProcess() != null)
            {
                MessageBox.Show("Program is already running");
                Environment.Exit(1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static Process PriorProcess()
        {
            Process result;
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
                foreach (Process process in processesByName)
                {
                    if (process.Id != currentProcess.Id && process.MainModule.FileName == currentProcess.MainModule.FileName)
                    {
                        return process;
                    }
                }
                result = null;
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
