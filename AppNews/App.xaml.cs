namespace AppNews;
using AppNews.Views;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new PrincipalView();
	}
}
