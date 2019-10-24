using System;
using System.Collections.Generic;
using System.Text;

namespace Analogy.Interfaces
{
    public class AnalogyLogMessageCustomEqualityComparer :IEqualityComparer<AnalogyLogMessage>
    {
        public bool Equals(AnalogyLogMessage x, AnalogyLogMessage y)
        {
            if (x is null || y is null) return false;
            return x.Equals(y);
        }

        public int GetHashCode(AnalogyLogMessage obj)
        {
            return obj.GetHashCode();
        }
    }
}
