namespace AppNews;
using AppNews.Views;
using AppNews.Views.Usuarios;
using AppNews.Views.Administrador;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        #region Rutas
        Routing.RegisterRoute("//principal", typeof(PrincipalView));
        Routing.RegisterRoute("//login", typeof(LoginView));
        Routing.RegisterRoute("//principaladmin", typeof(PrincipalViewAD));
        Routing.RegisterRoute("//addnoticia", typeof(AgregarNoticiaView));
        Routing.RegisterRoute("//editnoticia", typeof(EditarNoticiaView));
        Routing.RegisterRoute("//userview", typeof(NoticiasView));
		#endregion
		MainPage = new NoticiasView();
	}
}
