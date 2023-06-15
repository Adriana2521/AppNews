namespace AppNews;
using AppNews.Views;
using AppNews.Views.Usuarios;
using AppNews.Views.Administrador;
using AppNews.Services;

public partial class App : Application
{
	public App(AuthService authService, LoginService login)
	{
		InitializeComponent();
        MainPage = new AppShell(authService, login);
        #region Rutas
        Routing.RegisterRoute("//principal", typeof(PrincipalView));
        Routing.RegisterRoute("//login", typeof(LoginView));
        Routing.RegisterRoute("//principaladmin", typeof(PrincipalViewAD));
        Routing.RegisterRoute("//addnoticia", typeof(AgregarNoticiaView));
        Routing.RegisterRoute("//editnoticia", typeof(EditarNoticiaView));
        Routing.RegisterRoute("//userview", typeof(NoticiasView));
        #endregion
    }
}
