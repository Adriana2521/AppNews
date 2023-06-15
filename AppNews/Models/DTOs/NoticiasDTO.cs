using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNews.Models.DTOs
{
    public class NoticiasDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Caption { get; set; }

        public string Contenido { get; set; } = null!;

        public DateOnly FechaPublicacion { get; set; }

        public int AutorId { get; set; }

        public virtual UsuarioDTO Autor { get; set; }
    }
}
