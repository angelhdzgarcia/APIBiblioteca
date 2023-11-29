using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private ProfesorDAO profesoresDAO =new ProfesorDAO();

        [HttpPost("autentication")]
        public string login([FromBody] Profesor prof)
        {
            var profesor = profesoresDAO.login(prof.Usuario, prof.Pass);

            if (profesor != null)
            {
                return profesor.Usuario;
            }
            else
            {
                return null;
            }
        }

        /**
         *EndPoint para obtener todos los  profesores
         */
        [HttpGet("profesores")]
        public ActionResult<List<Profesor>> GetProfesores()
        {
            List<Profesor> profesores = profesoresDAO.seleccionarTodos();

            if (profesores == null || profesores.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron profesores.
            }
            return profesores;
        }
        /**
         *EndPoint para obtener un profesor especifico
         */
        [HttpGet("profesor")]
        public Profesor getProfesor(string usuario)
        {
            return profesoresDAO.seleccionar(usuario);
        }

        /**
         *EndPoint para insertar un profesor
         */
        [HttpPost("profesor")]
        public bool insertarProfesor([FromBody] Profesor profesor)
        {
            return profesoresDAO.insertarProfesor(profesor.Usuario,profesor.Pass, 
                profesor.Nombre, profesor.Email);
        }

        /**
         *EndPoint para actualizar datos de un profesor
         */
        [HttpPut("profesor")]
        public bool actualizarProfesor([FromBody]Profesor profesor)
        {
            return profesoresDAO.actualizar(profesor.Usuario, profesor.Pass,
                profesor.Nombre, profesor.Email);
        }
        
    }
}
