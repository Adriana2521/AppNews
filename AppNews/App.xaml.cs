namespace AppNews;
using AppNews.Views.Administrador;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new PrincipalViewAD();
	}
}
