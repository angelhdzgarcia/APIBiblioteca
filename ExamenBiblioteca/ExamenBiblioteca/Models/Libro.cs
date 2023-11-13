using System;
using System.Collections.Generic;

namespace ExamenBiblioteca.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int? Capitulos { get; set; }

    public int? Paginas { get; set; }

    public float? Precio { get; set; }

    public int? AutorId { get; set; }

    public virtual Autor? Autor { get; set; }
}
