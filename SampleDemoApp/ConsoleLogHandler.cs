using LoanManagement.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDemoApp
{
    /// <summary>
    /// A sample console log handler.
    /// </summary>
    class ConsoleLogHandler : ILog
    {
        public void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine(string.Format("{0}:{1}", logLevel, message));
        }
    }
}
