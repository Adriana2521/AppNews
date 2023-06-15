using AppNewsApi.Models;

namespace AppNewsApi.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Rol { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public ICollection<Noticias>? Noticias { get; set; }
    }
}
