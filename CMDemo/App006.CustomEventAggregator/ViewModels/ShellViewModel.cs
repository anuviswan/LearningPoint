using Caliburn.Micro;

namespace App006.CustomEventAggregator.ViewModels
{
    public class ShellViewModel:Screen
    {
        public UserListViewModel UserListVM { get; set; } = IoC.Get<UserListViewModel>();

        public UserProfileViewModel UserProfileVM { get; set; } = IoC.Get<UserProfileViewModel>();
    }
}
