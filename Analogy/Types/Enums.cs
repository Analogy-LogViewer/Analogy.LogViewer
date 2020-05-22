using System.ComponentModel.DataAnnotations;

namespace Analogy.Types
{
    public enum UpdateMode
    {
        [Display(Name = "Never")]
        Never,
        [Display(Name = "Each Startup")]
        EachStartup,
        [Display(Name = "Once a Week")]
        OnceAWeek,
        [Display(Name = "Once a Month")]
        OnceAMonth,
    }
}
