using AppNews.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppNews.Services
{
    public class NoticiaService
    {
        private readonly LoginService Login;
        private readonly HttpClient httpcliente;
        private readonly string url = "http://seguridaddocentes.itesrc.net/";
        public NoticiaService(LoginService Login)
        {
            this.Login = Login;

            httpcliente = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
            // Agregar autentificacion por token bearer
            httpcliente.DefaultRequestHeaders.Add("Autorization", "Bearer:"+ AuthService.ReadToken().Result);
        }
        public async Task<List<UsuarioDTO>> GetAll()
        {
            var response = await httpcliente.GetAsync("api/noticias");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Cerrar sesion
                Login.Logout();
            }
            return null;
        }
    }
}
