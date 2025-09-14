using LoginDemo.ViewModels;

namespace LoginDemo.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}