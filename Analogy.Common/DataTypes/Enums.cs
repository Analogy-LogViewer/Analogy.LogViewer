using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    public enum DataProviderFactoryStatus
    {
        NotSet,
        Enabled,
        Disabled,
    }
    public enum PreDefinedQueryType
    {
        Contains,
        Equals,
    }
    public enum UpdateMode
    {
        [Display(Name = "Never")] Never,
        [Display(Name = "Each Startup")] EachStartup,
        [Display(Name = "Once a Week")] OnceAWeek,
        [Display(Name = "Once a Month")] OnceAMonth,
    }
    public enum LogLevelSelectionType
    {
        Single,
        Multiple,
    }
    public enum BuiltInSearchPanelMode
    {
        Search,
        Filter,
    }
    public enum AnalogyLookAndFeelStyle
    {
        [Browsable(false)] Flat,
        [Browsable(false)] UltraFlat,
        [Browsable(false)] Style3D,
        [Browsable(false)] Office2003,
        [Browsable(false)] Skin,
    }
    public enum AnalogyCommandLayout
    {
        Classic,
        Simplified,
    }
    public enum FontSelectionType
    {
        Default,
        Normal,
        Large,
        VeryLarge,
        Manual,
    }

    public enum SettingsMode
    {
        None = -1,
        PerUser,
        ApplicationFolder,
        ProgramData,
    }
    public enum TimeOffsetType
    {
        None,
        Predefined,
        UtcToLocalTime,
        LocalTimeToUtc,
    }
    public enum DataSourceType
    {
        Client,
        Server,
        NetworkPath,
        LocalPath,
    }
}