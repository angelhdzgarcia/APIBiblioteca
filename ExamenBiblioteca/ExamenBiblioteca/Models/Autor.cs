﻿using System;
using System.Collections.Generic;

namespace ExamenBiblioteca.Models;

public partial class Autor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
