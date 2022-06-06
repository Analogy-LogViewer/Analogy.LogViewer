using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Common.Interfaces;
using Analogy.DataTypes;

namespace Analogy.Interfaces
{
    public interface IAnalogyUserSettings: IUserSettingsManager
    {
        public MainFormType MainFormType { get; set; }
    }
}
