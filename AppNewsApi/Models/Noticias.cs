using System;
using System.Collections.Generic;

namespace AppNewsApi.Models;

public partial class Noticias
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Caption { get; set; }

    public string Contenido { get; set; } = null!;

    public DateOnly FechaPublicacion { get; set; }

    public int? AutorId { get; set; }

    public virtual Usuarios? Autor { get; set; }
}
