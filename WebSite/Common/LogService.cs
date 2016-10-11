﻿using System;
using System.IO;
using System.Text;

namespace AzureBackupManager.Common
{
    public class LogService
    {
        private readonly string _localFolderPath;
        public LogService()
        {
            _localFolderPath = SettingsFactory.GetStaticLocalFolderPath();
        }
        public void WriteLog(string message)
        {
            StreamWriter file = new StreamWriter(GetFilename(), true, Encoding.UTF8);
            file.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: {message}");
            file.Close();
        }
        public string ReadLog()
        {
            try
            {
                StreamReader file = new StreamReader(GetFilename(), Encoding.UTF8);
                var s = file.ReadToEnd();
                file.Close();
                return s;
            }
            catch (FileNotFoundException)
            { return null; }
        }
        public string GetFilename()
        {
            return _localFolderPath + $"{DateTime.Now.ToString("yyyy-MM")}_log.txt";
        }
    }
}