using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Analogy.Interfaces;
using Microsoft.Extensions.Logging;

namespace Analogy.Common.Managers
{
    public class EmptyAnalogyLogger : ILogger
    {
        public void LogInformation(string message, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
        }

        public void LogWarning(string message, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
        }

        public void LogDebug(string message, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
        }

        public void LogError(string message, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
        }

        public void LogCritical(string message, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
        }

        public void LogException(string message, Exception ex, string source = "", string memberName = "",
            int lineNumber = 0,
            string filePath = "")
        {
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            try
            {
                AnalogyLogLevel level;
                string text = formatter(state, exception);

                switch (logLevel)
                {
                    case LogLevel.Trace:
                        LogInformation(text);
                        break;
                    case LogLevel.Debug:
                        LogDebug(text);
                        break;
                    case LogLevel.Information:
                        LogInformation(text);
                        break;
                    case LogLevel.Warning:
                        LogWarning(text);
                        break;
                    case LogLevel.Error:
                    case LogLevel.Critical:
                        LogError(text);
                        break;
                    case LogLevel.None:
                        level = AnalogyLogLevel.None;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
                }
            }
            catch (Exception e)
            {
                LogException($"error: {e.Message}",e);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }
    }
}