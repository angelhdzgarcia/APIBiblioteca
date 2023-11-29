using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ALumnosController : ControllerBase
    {
        private AlumnoDAO alumnosDAO = new AlumnoDAO();

        /**
         *EndPoint para obtener un alumno  especifico
         */
        [HttpGet("alumno")]
        public Alumno getAlumno(int id)
        {
            return alumnosDAO.seleccionar(id);
        }

        /**
         *EndPoint para obtener los alumnos asignados a un profesor
         */
        [HttpGet("alumnosProfesor")]
        public List<AlumnoProfesor> alumnosProfesor(string usuario)
        {
            return alumnosDAO.seleccionarAlumnosProfesor(usuario);
        }

        /**
         *EndPoint para insertar y matricular un alumno
         */
        [HttpPost("alumno")]
        public bool insertarMatricular([FromBody] Alumno alumno, int id_asig)
        {
            return alumnosDAO.insertarMatricula(alumno.Dni, alumno.Nombre,
                alumno.Direccion, alumno.Edad, alumno.Email, id_asig);
        }

        /**
         *EndPoint para actualizar datos del alumno
         */
        [HttpPut("alumno")]
        public bool actualizarAlumno([FromBody] Alumno alumno)
        {
            return alumnosDAO.actualizar(alumno.Id, alumno.Dni, alumno.Nombre,
                alumno.Direccion, alumno.Edad, alumno.Email);
        }

        /**
         *EndPoint para eliminar un alumno
         */
        [HttpDelete("alumno")]
        public bool eliminarAlumno(int id)
        {
            return alumnosDAO.eliminarCalificacionesAlumno(id);
        }
    }
}
