using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Analogy.Interfaces
{
    public class AnalogyLogMessageCustomEqualityComparer : IEqualityComparer<AnalogyLogMessage>
    {
        public bool CompareDate { get; set; } = true;
        public bool CompareID { get; set; } = true;
        public bool CompareText { get; set; } = true;
        public bool CompareCategory { get; set; } = true;
        public bool CompareSource { get; set; } = true;
        public bool CompareModule { get; set; } = true;
        public bool CompareMethodName { get; set; } = true;
        public bool CompareFileName { get; set; } = true;
        public bool CompareUser { get; set; } = true;
        public bool CompareLineNumber { get; set; } = true;
        public bool CompareProcessID { get; set; } = true;
        public bool CompareThread { get; set; } = true;
        public bool CompareLevel { get; set; } = true;
        public bool CompareClass { get; set; } = true;
        public bool CompareParameters { get; set; } = true;

        public bool Equals(AnalogyLogMessage x, AnalogyLogMessage y)
        {
            if (x is null || y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (CompareDate && !x.Date.Equals(y.Date))
                return false;
            if (CompareID && !x.ID.Equals(y.ID))
                return false;
            if (CompareText && !x.Text.Equals(y.Text))
                return false;
            if (CompareCategory && x.Category != y.Category)
                return false;
            if (CompareSource && x.Source != y.Source)
                return false;
            if (CompareModule && x.Module != y.Module)
                return false;
            if (CompareMethodName && x.MethodName != y.MethodName)
                return false;
            if (CompareFileName && x.FileName != y.FileName)
                return false;
            if (CompareUser && x.User != y.User)
                return false;
            if (CompareLineNumber && !x.LineNumber.Equals(y.LineNumber))
                return false;
            if (CompareProcessID && !x.ProcessID.Equals(y.ProcessID))
                return false;
            if (CompareThread && !x.Thread.Equals(y.Thread))
                return false;
            if (CompareLineNumber && !x.LineNumber.Equals(y.LineNumber))
                return false;
            if (CompareLevel && !x.Level.Equals(y.Level))
                return false;
            if (CompareParameters)
            {
                if (x.Parameters is null && y.Parameters != null ||
                    x.Parameters != null && y.Parameters is null)
                    return false;
                return x.Parameters is null && y.Parameters is null ||
                       x.Parameters.SequenceEqual(y.Parameters);
            }

            return true;
        }

        public int GetHashCode(AnalogyLogMessage obj)
        {
            unchecked
            {
                var hashCode = CompareDate ? obj.Date.GetHashCode() : 1;

                if (CompareID)
                    hashCode = (hashCode * 397) ^ obj.ID.GetHashCode();
                if (CompareText)
                    hashCode = (hashCode * 397) ^ (obj.Text != null ? obj.Text.GetHashCode() : 0);
                if (CompareCategory)
                    hashCode = (hashCode * 397) ^ (obj.Category != null ? obj.Category.GetHashCode() : 0);
                if (CompareSource)
                    hashCode = (hashCode * 397) ^ (obj.Source != null ? obj.Source.GetHashCode() : 0);
                if (CompareMethodName)
                    hashCode = (hashCode * 397) ^ (obj.MethodName != null ? obj.MethodName.GetHashCode() : 0);
                if (CompareFileName)
                    hashCode = (hashCode * 397) ^ (obj.FileName != null ? obj.FileName.GetHashCode() : 0);
                if (CompareLineNumber)
                    hashCode = (hashCode * 397) ^ obj.LineNumber;
                if (CompareClass)
                    hashCode = (hashCode * 397) ^ (int)obj.Class;
                if (CompareLevel)
                    hashCode = (hashCode * 397) ^ (int)obj.Level;
                if (CompareModule)
                    hashCode = (hashCode * 397) ^ (obj.Module != null ? obj.Module.GetHashCode() : 0);
                if (CompareProcessID)
                    hashCode = (hashCode * 397) ^ obj.ProcessID;
                if (CompareThread)
                    hashCode = (hashCode * 397) ^ obj.Thread;
                if (CompareParameters)
                {
                    if (obj.Parameters != null && obj.Parameters.Any())
                    {
                        foreach (string parameter in obj.Parameters)
                        {
                            if (!string.IsNullOrEmpty(parameter))
                                hashCode = (hashCode * 397) ^ parameter.GetHashCode();
                        }
                    }
                }
                if (CompareUser)
                    hashCode = (hashCode * 397) ^ (obj.User != null ? obj.User.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
