using ExamenBiblioteca.Models;
using ExamenBiblioteca.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorDAO autorDAO = new AutorDAO();

        /**
         *EndPoint para obtener todos los  autores
         */
        [HttpGet("autores")]
        public ActionResult<List<Autor>> GetAutores()
        {
            List<Autor> autores = autorDAO.seleccionarTodos();

            if (autores == null || autores.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron profesores.
            }
            return autores;
        }

        /**
         *EndPoint para insertar un autor
         */
        [HttpPost("autor")]
        public bool insertarProfesor([FromBody] Autor autor)
        {
            return autorDAO.insertar(autor.Id, autor.Nombre);
        }
    }
}
