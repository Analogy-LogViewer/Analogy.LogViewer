using Analogy.Interfaces;
using Analogy.Interfaces.Winforms;

namespace Analogy.Managers
{
    public class NotificationManager : INotificationReporterWinforms
    {
        public event EventHandler<IAnalogyNotificationWinforms> OnNewNotification;
        public void RaiseNotification(IAnalogyNotificationWinforms notification, bool showAsPopup)
        {
            OnNewNotification?.Invoke(this, notification);
        }

        public void RaiseNotification(IAnalogyNotification notification, bool showAsPopup)
        {
        }
    }
}