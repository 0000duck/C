﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShowAndroidModel
{
    static class Program
    {
        internal static string AdbPath = @"F:\Android\android-sdk\platform-tools\adb.exe";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.IO.File.Exists("config.db"))
            {
                //AdbPath = System.IO.File.ReadAllText("config.db");
                Application.Run(new Form1());
            }
            else
            {
                if (System.IO.File.Exists(string.Format(@"{0}\Android\android-sdk\platform-tools\adb.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))))
                {
                    System.IO.File.WriteAllText("config.db", string.Format(@"{0}\Android\android-sdk\platform-tools\adb.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));
                }else if (System.IO.File.Exists(string.Format(@"{0}\Android\android-sdk\platform-tools\adb.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))))
                {
                    System.IO.File.WriteAllText("config.db", string.Format(@"{0}\Android\android-sdk\platform-tools\adb.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)));
                }
                else
                {
                    Application.Run(new SetupForm());
                    AdbPath = System.IO.File.ReadAllText("config.db");
                    Application.Run(new Form1());
                    return;
                }
                //AdbPath = System.IO.File.ReadAllText("config.db");
                Application.Run(new Form1());
            }
            
        }
    }
}
