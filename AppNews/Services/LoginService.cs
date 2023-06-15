using AppNews.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppNews.Services
{
    public class LoginService
    {
        private readonly HttpClient cliente = new();
        private readonly string url = "http://seguridaddocentes.itesrc.net";
        private readonly AuthService auth;
        public LoginService(AuthService auth)
        {
            this.auth = auth;
            cliente.BaseAddress =new Uri(url);
        }
        public async Task<bool> Login(LoginDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Usuario) ||string.IsNullOrWhiteSpace(dto.Contraseña))
            {
                throw new ArgumentException("Escriba el nombre de usuario y contraseña");
            }
            var response = await cliente.PostAsJsonAsync("api/login", dto);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                await auth.WriteToken(token);
                return true;
            }
            return false;
        }
        public void Logout()
        {
            auth.RemoveToken();
            Shell.Current.GoToAsync("/login");
        }
    }
}
