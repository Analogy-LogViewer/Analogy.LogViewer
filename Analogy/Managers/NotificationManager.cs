using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;

namespace Analogy.Managers
{
    public class NotificationManager : INotificationReporter
    {
        public event EventHandler<IAnalogyNotification> OnNewNotification;
        public void RaiseNotification(IAnalogyNotification notification, bool showAsPopup)
        {
            OnNewNotification?.Invoke(this, notification);
        }
    }
}