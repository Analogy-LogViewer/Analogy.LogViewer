using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Analogy.Interfaces;
using Analogy.Managers;

namespace Analogy
{
    public class AnalogyLogger: IAnalogyLogger
    {
        public static readonly Lazy<IAnalogyLogger> _instance = new Lazy<IAnalogyLogger>(()=>new AnalogyLogger());
        public static IAnalogyLogger Instance => _instance.Value;
        private string DateTimeWithMilliseconds => DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", DateTimeFormatInfo.InvariantInfo);
        private static readonly Process CurrentProcess = Process.GetCurrentProcess();
        private DateTime ProcessStartTime => CurrentProcess.StartTime;
        private AnalogyLogger()
        {
            
        }
        public virtual void LogEvent(string source, string message, [CallerMemberName] string memberName = "" , [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
        {
            AnalogyLogManager.Instance.LogEvent(GetFormattedString(message, memberName, lineNumber, filePath), source);
        }

        public virtual void LogWarning(string source, string message, [CallerMemberName] string memberName = "" , [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
        {
            AnalogyLogManager.Instance.LogWarning(GetFormattedString(message, memberName, lineNumber, filePath), source);
        }

        public virtual void LogDebug(string source, string message, [CallerMemberName] string memberName = "" , [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
        {
            AnalogyLogManager.Instance.LogDebug(GetFormattedString(message, memberName, lineNumber, filePath), source);
        }

        public virtual void LogError(string source, string message, [CallerMemberName] string memberName = "" , [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
        {
            AnalogyLogManager.Instance.LogError("Error: " + GetFormattedString(message, memberName, lineNumber, filePath),source);
        }

        public virtual void LogCritical(string source, string message, [CallerMemberName] string memberName = "" , [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
        {
            AnalogyLogManager.Instance.LogCritical(GetFormattedString(message, memberName, lineNumber, filePath), source);
        }

        public virtual void LogException(Exception ex, string source, string message, [CallerMemberName] string memberName = "" , [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
        {
            LogError(source,$"Error: {GetFormattedString(message,memberName,lineNumber,filePath)}. Exception: {ex}");

        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetFormattedString(string message, string memberName, int lineNumber, string filePath) =>
            $"{message}. Member:{memberName}. Line:{lineNumber}. Thread (managedID):{Thread.CurrentThread.ManagedThreadId}. Start Time:{ProcessStartTime}. Time:{DateTimeWithMilliseconds}. File: {filePath}";

    }

}

