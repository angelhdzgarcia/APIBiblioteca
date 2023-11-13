namespace ExamenBiblioteca.Models
{
    public class LibroAutor
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public int? Capitulos { get; set; }

        public int? Paginas { get; set; }

        public float? Precio { get; set; }

        public string? Autor { get; set; }

    }
}
