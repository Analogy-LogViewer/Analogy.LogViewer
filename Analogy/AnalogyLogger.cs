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
        private static readonly Lazy<IAnalogyLogger> _instance = new Lazy<IAnalogyLogger>(()=>new AnalogyLogger());
        public static IAnalogyLogger Instance => _instance.Value;
        private string DateTimeWithMilliseconds => DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", DateTimeFormatInfo.InvariantInfo);
        private static readonly Process CurrentProcess = Process.GetCurrentProcess();
        private DateTime ProcessStartTime => CurrentProcess.StartTime;
        private AnalogyLogger()
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

    }

}

