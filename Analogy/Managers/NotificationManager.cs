using Analogy.Interfaces;

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
