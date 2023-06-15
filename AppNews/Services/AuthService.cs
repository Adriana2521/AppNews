using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppNews.Services
{
    public class AuthService
    {
        public bool IsLogged;
        private string token = "";
        public static bool IsAuthentificated => ReadToken().Result!=null;
        public AuthService()
        {

        }

        public IEnumerable<Claim> Claims
        {
            get
            {
                JwtSecurityTokenHandler handler = new();
                var tk = handler.ReadJwtToken(token);
                return tk.Claims;
            }
        }

        public bool IsValid
        {
            get
            {
                JwtSecurityTokenHandler handler = new();
                if (string.IsNullOrWhiteSpace(token))
                {
                    var tk = handler.ReadJwtToken(token);
                    return tk.ValidTo >= DateTime.UtcNow;
                }
                return false;
            }
        }

        //Read Token, Remove Token, Write Token
        public async Task WriteToken(string token)
        {
            this.token = token;
            // Guardar el token
            await SecureStorage.SetAsync("JwtToken", token);
        }

        public static async Task<string> ReadToken()
        {
            //Leer el token
            var token = await SecureStorage.GetAsync("JwtToken");
            return token;
        }

        public void RemoveToken()
        {
            //Eliminar el token
            SecureStorage.Remove("JwtToken");
            token=null;
        }
    }
}
