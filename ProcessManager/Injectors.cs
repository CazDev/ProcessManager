using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager
{
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
}
