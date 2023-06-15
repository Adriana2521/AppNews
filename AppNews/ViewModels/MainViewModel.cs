using AppNews.Models.DTOs;
using AppNews.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppNews.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand CerrarSesionCommand { get; set; }
        public ContentPage Vista { get; set; }

        private readonly LoginService login;
        private readonly AuthService auth;
        public MainViewModel(AuthService auth,LoginService login)
        {

            this.auth = auth;
            this.login = login;
            CerrarSesionCommand = new Command(CerrarSesion);
        }
        private void CerrarSesion(object obj)
        {
            login.Logout();
        }
        public void PropertyChange(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
