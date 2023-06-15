using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNews.Models.DTOs
{
    public class UsuarioDTO
    {
        public string Rol { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public ICollection<NoticiasDTO> Noticias { get; set; }
    }
}
