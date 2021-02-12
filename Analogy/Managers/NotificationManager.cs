using Analogy.Interfaces;
using System;

namespace Analogy.Managers
{
    public class NotificationManager : INotificationReporter
    {
        private static readonly Lazy<NotificationManager> _instance = new Lazy<NotificationManager>();
        public static NotificationManager Instance => _instance.Value;
        public event EventHandler<IAnalogyNotification> OnNewNotification;
        public void RaiseNotification(IAnalogyNotification notification, bool showAsPopup)
        {
            OnNewNotification?.Invoke(this, notification);
        }
    }
}
