﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Brave_Dev_x86_Launcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture1 = CultureInfo.CurrentUICulture;
            if (File.Exists(@"Brave Dev x86\Brave.exe"))
            {
                var sb = new System.Text.StringBuilder();
                string[] CommandLineArgs = Environment.GetCommandLineArgs();
                for (int i = 1; i < CommandLineArgs.Length; i++)
                {
                    if (CommandLineArgs[i].Contains("="))
                    {
                        string[] test = CommandLineArgs[i].Split(new char[] { '=' }, 2);
                        sb.Append(" " + test[0] + "=\"" + test[1] + "\"");
                    }
                    else
                    {
                        sb.Append(" " + CommandLineArgs[i]);
                    }
                }
                if (!File.Exists(@"Brave Dev x86\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(@"Brave Dev x86\Profile.txt") + sb.ToString();
                    _ = Process.Start(@"Brave Dev x86\Brave.exe", Arguments);
                }
                else
                {
                    String Arguments = File.ReadAllText(@"Brave Dev x86\Profile.txt") + sb.ToString();
                    _ = Process.Start(@"Brave Dev x86\Brave.exe", Arguments);
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                _ = MessageBox.Show("Brave ist nicht installiert", "Brave Dev x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                _ = MessageBox.Show("Brave Portable не найден", "Brave Dev x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _ = MessageBox.Show("Brave is not installed", "Brave Dev x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
