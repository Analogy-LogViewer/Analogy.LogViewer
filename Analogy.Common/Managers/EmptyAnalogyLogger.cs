using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.Common.Managers
{
    public class EmptyAnalogyLogger : IAnalogyLogger
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
    }
}