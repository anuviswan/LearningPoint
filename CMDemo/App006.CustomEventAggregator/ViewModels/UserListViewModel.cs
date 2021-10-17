using App006.CustomEventAggregator.Messages;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;

namespace App006.CustomEventAggregator.ViewModels
{
    public class UserListViewModel:Screen
    {
        private readonly IEventAggregator _eventAggregator;
        public UserListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            UserCollection = Enumerable.Range(1, 10).Select(x => $"User {x}").ToList();
            NotifyOfPropertyChange(nameof(UserCollection));

            PropertyChanged += ControlPropertyChanged;
        }

        private void ControlPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, nameof(SelectedUser)))
            {
                _eventAggregator.PublishOnUIThreadAsync(new UserSelectionChangedMessage { UserName = SelectedUser });
            }
        }

        public List<string> UserCollection { get; set; }

        private string _selectedUser;
        public string SelectedUser 
        {
            get => _selectedUser;
            set
            {
                if (string.Equals(_selectedUser, value)) return;

                _selectedUser = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
