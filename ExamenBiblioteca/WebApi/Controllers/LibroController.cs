using ExamenBiblioteca.Models;
using ExamenBiblioteca.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private LibroDAO libroDAO = new LibroDAO();

        /**
         *EndPoint para obtener un libro  especifico
         */
        [HttpGet("libro")]
        public Libro getAutor(int id)
        {
            return libroDAO.seleccionar(id);
        }

        /**
         *EndPoint para obtener un libro  especifico
         */
        [HttpGet("libroT")]
        public Libro getAutor(string titulo)
        {
            return libroDAO.seleccionarTitulo(titulo);
        }

        /**
         *EndPoint para obtener todos los  autores
         */
        [HttpGet("libros")]
        public ActionResult<List<LibroAutor>> GetLibros()
        {
            List<LibroAutor> libros = libroDAO.seleccionarTodos();

            if (libros == null || libros.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron profesores.
            }
            return libros;
        }

        /**
         *EndPoint para insertar un autor
         */
        [HttpPost("libro")]
        public bool insertarLibro([FromBody] Libro libro)
        {
            return libroDAO.insertar(libro.Id, libro.Titulo, (int)libro.Capitulos, (int)libro.Paginas, (int)libro.Precio, (int)libro.AutorId);
        }
    }
}
