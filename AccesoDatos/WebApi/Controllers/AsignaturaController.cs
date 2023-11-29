using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   
    [Route("api")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private AsignaturaDAO asignaturasDAO = new AsignaturaDAO();

            /**
             *EndPoint para obtener todas las materias
             */
            [HttpGet("asignaturas")]
            public ActionResult<List<Asignatura>> GetAsignaturas()
            {
                List<Asignatura> asignaturas = asignaturasDAO.seleccionarTodas();

                if (asignaturas == null || asignaturas.Count == 0)
                {
                    return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron materias.
                }
                return asignaturas;
            }
            /**
             *EndPoint para obtener una materia en especifico
             */
            [HttpGet("asignatura")]
            public Asignatura getAsignatura(int id)
            {
                return asignaturasDAO.seleccionar(id);
            }

            /**
             *EndPoint para insertar una materia
             */
            [HttpPost("asignatura")]
            public bool insertarAsignatura([FromBody] Asignatura asignatura)
            {
                return asignaturasDAO.insertarAsignatura(asignatura.Id, asignatura.Nombre, asignatura.Creditos,
                    asignatura.Profesor);
            }

            /**
             *EndPoint para actualizar datos de una materia
             */
            [HttpPut("asignatura")]
            public bool actualizarAsignatura([FromBody] Asignatura asignatura)
            {
                return asignaturasDAO.actualizar(asignatura.Id, asignatura.Nombre,
                    asignatura.Creditos, asignatura.Profesor);
            }
    }
}
