using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    [Serializable]
    public class FilterCriteriaUIOption
    {
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public bool CheckMember { get; set; }


        public FilterCriteriaUIOption(string displayMember, string valueMember, bool checkMember)
        {
            DisplayMember = displayMember;
            ValueMember = valueMember;
            CheckMember = checkMember;
        }
    }
}
