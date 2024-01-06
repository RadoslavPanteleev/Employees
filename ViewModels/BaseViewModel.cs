using CommunityToolkit.Mvvm.ComponentModel;

namespace Employees.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
        }
        
        public event EventHandler<string>? NotificationRequest;
        protected void ShowNotification(string notification)
        {
            if (this.NotificationRequest is not null)
            {
                this.NotificationRequest(this, notification);
            }
        }
    }
}
