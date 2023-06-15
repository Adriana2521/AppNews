using AppNews.Models.DTOs;
using AppNews.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace AppNews.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly LoginService login;
        #region Comandos
        public ICommand IniciarSesionCommand { get; set; }
        public string Mensaje { get; set; }
        #endregion
        public LoginDTO Credenciales { get; set; } = new();
        public LoginViewModel(LoginService login)
        {
            this.login=login;
            IniciarSesionCommand = new Command(IniciarSesion);
        }
        private async void IniciarSesion(object obj)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    if (!await login.Login(Credenciales))
                    {
                        Mensaje = "Nombre de usuario o contraseña incorrecta";
                        Actualizar(nameof(Mensaje));
                    }
                    else
                    {
                        await Shell.Current.GoToAsync("//main");
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Actualizar(Mensaje);
            }
        }

        private void Actualizar(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
