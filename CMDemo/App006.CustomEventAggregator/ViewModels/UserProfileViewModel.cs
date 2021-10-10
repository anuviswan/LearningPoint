using App006.CustomEventAggregator.Messages;
using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;

namespace App006.CustomEventAggregator.ViewModels
{
    public class UserProfileViewModel : Screen, IHandle<UserSelectionChangedMessage>
    {
        public UserProfileViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.SubscribeOnUIThread(this);
        }
        public string UserName { get; set; }
        public Task HandleAsync(UserSelectionChangedMessage message, CancellationToken cancellationToken)
        {
            UserName = message.UserName;
            NotifyOfPropertyChange(nameof(UserName));
            return Task.CompletedTask;
        }
    }
}
