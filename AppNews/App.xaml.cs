namespace AppNews;
using AppNews.Views.Usuarios;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NoticiasView();
	}
}
