using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal class Logger
    {
        private string filePath = "log.txt";
    
        public void  Log(string message)
        {
            string logMessage = $"{DateTime.Now} - {message}";

            File.AppendAllText(filePath, logMessage);
        }
    }
}
