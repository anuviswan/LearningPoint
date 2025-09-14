using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginDemo.Services;

namespace LoginDemo.ViewModels;

public partial class LoginViewModel(IUserService userService) :ObservableObject
{

    [ObservableProperty]
    private string? userName;

    [ObservableProperty]
    private string? password;


    [RelayCommand(CanExecute = nameof(CanExecuteLogin))]
    private void ExecuteLogin()
    {
        if((UserName is not null) && (Password is not null) && userService.ValidateCredentials(UserName, Password))
        {
            Shell.Current.GoToAsync("HomePage");
        }
    }

    public bool CanExecuteLogin()
    {
        return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
    }
}
