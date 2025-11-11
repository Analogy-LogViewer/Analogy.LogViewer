using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;

namespace Analogy.Managers
{
    public class NotificationManager : INotificationReporterWinForms
    {
        public event EventHandler<IAnalogyNotificationWinForms> OnNewNotification;
        public void RaiseNotification(IAnalogyNotificationWinForms notification, bool showAsPopup)
        {
            OnNewNotification?.Invoke(this, notification);
        }

        public void RaiseNotification(IAnalogyNotification notification, bool showAsPopup)
        {
        }
    }
}