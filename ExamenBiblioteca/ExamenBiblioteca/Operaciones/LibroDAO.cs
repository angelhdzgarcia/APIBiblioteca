using ExamenBiblioteca.Context;
using ExamenBiblioteca.Models;

namespace ExamenBiblioteca.Operaciones
{
    public class LibroDAO
    {
        //Creamos un objeto de contexto de DB
        public LibreriaContext contexto = new LibreriaContext();

        //Método para seleccionar todos los libros
        public List<LibroAutor> seleccionarTodos()
        {
            var query = from a in contexto.Libros
                        join m in contexto.Autors on a.AutorId
                        equals m.Id
                        join nom in contexto.Autors on
                        m.Id equals nom.Id
                        select new LibroAutor
                        {
                            Titulo = a.Titulo,
                            Autor = m.Nombre,
                            Capitulos = a.Capitulos,
                            Paginas = a.Paginas,
                            Precio = a.Precio
                        };
            return query.ToList();
            //var libros = contexto.Libros.ToList<Libro>();
            //return libros;
        }

        //Método para seleccionar un libro en especifico.
        public Libro seleccionar(int id)
        {
            var libro = contexto.Libros.Where(a => a.Id == id).FirstOrDefault();
            return libro;
        }

        //Método para seleccionar un libro en especifico.
        public Libro seleccionarTitulo(string titulo)
        {
            var libro = contexto.Libros.Where(a => a.Titulo == titulo).FirstOrDefault();
            return libro;
        }

        //Método para insertar un nuevo libro en la BD.
        public bool insertar(int id, string titulo, int capitulos, int paginas, int precio, int autorId)
        {
            try
            {
                Libro libro = new Libro();
                libro.Id = id;
                libro.Titulo = titulo;
                libro.Capitulos = capitulos;
                libro.Paginas = paginas;
                libro.Precio = precio;
                libro.AutorId = autorId;

                contexto.Libros.Add(libro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
