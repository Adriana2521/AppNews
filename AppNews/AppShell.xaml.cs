using AppNews.Services;
using AppNews.ViewModels;

namespace AppNews;

public partial class AppShell : Shell
{
    public AppShell(AuthService service,LoginService login)
	{
		InitializeComponent();
        this.BindingContext = new MainViewModel(service, login);
    }
}
