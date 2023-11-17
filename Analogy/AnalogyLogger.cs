using Analogy.Interfaces;
using Analogy.Managers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Analogy
{
    public class AnalogyLogger: ILogger
    {
        private string DateTimeWithMilliseconds => DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", DateTimeFormatInfo.InvariantInfo);
        private static readonly Process CurrentProcess = Process.GetCurrentProcess();
        private DateTime ProcessStartTime => CurrentProcess.StartTime;
        public AnalogyLogger()
        {
            
        }

        public void LogInformation(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => AnalogyLogManager.Instance.LogInformation(GetFormattedString(message, memberName, lineNumber, filePath), source);

        public void LogWarning(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => AnalogyLogManager.Instance.LogWarning(GetFormattedString(message, memberName, lineNumber, filePath), source);

        public void LogDebug(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => AnalogyLogManager.Instance.LogDebug(GetFormattedString(message, memberName, lineNumber, filePath), source);

        public void LogError(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => AnalogyLogManager.Instance.LogError(GetFormattedString(message, memberName, lineNumber, filePath), source);

        public void LogCritical(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
       => AnalogyLogManager.Instance.LogCritical(GetFormattedString(message, memberName, lineNumber, filePath), source);
        public void LogException(string message, Exception ex, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
       => LogError($"Error: {GetFormattedString(message,memberName,lineNumber,filePath)}. Exception: {ex}", source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetFormattedString(string message, string memberName, int lineNumber, string filePath) =>
            $"{message}. Member:{memberName}. Line:{lineNumber}. Thread (managedID):{Thread.CurrentThread.ManagedThreadId}. Start Time:{ProcessStartTime}. Time:{DateTimeWithMilliseconds}. File: {filePath}";

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
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
                LogException($"error: {e.Message}", e);
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