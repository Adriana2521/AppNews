using System;
using System.Collections.Generic;

namespace AppNewsApi.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Noticias> Noticias { get; set; } = new List<Noticias>();
}
