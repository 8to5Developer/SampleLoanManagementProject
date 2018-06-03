using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Core.Logging
{
    public interface ILog
    {
        /// <summary>
        /// Logs a specific message.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The custome message.</param>
        void Log(LogLevel logLevel, string message);
    }


    /// <summary>
    /// Stores the enumeration of the log levels.
    /// </summary>
    public enum LogLevel
    {
        Trace,
        Debug,
        Warning,
        Error,
        Critical,
        None
    }
}
