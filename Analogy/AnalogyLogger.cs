using System;
using System.Runtime.CompilerServices;

namespace Analogy
{
    public class AnalogyLogger
    {
        public virtual void LogEvent(string source, string message, string memberName = "", int lineNumber = 0, string filePath = "")
        {

        }

        public virtual void LogWarning(string source, string message, string memberName = "", int lineNumber = 0, string filePath = "")
        {

        }

        public virtual void LogDebug(string source, string message, string memberName = "", int lineNumber = 0, string filePath = "")
        {

        }

        public virtual void LogError(string source, string message, string memberName = "", int lineNumber = 0, string filePath = "")
        {

        }

        public virtual void LogCritical(string source, string message, string memberName = "", int lineNumber = 0, string filePath = "")
        {

        }

        public virtual void LogException(Exception ex, string source, string message, string memberName = "", int lineNumber = 0, string filePath = "")
        {

        }


        public bool LogExceptionAndSkipCatchBlock(Exception ex, string source, string message,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "")
        {
            LogException(ex, source, message, memberName, lineNumber, filePath);
            return false;
        }

        public bool LogExceptionAndEnterCatchBlock(Exception ex, string source, string message,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "")
        {
            LogException(ex, source, message, memberName, lineNumber, filePath);
            return true;
        }
    }
}
