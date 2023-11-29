using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private CalificacionesDAO calificacionesDAO = new CalificacionesDAO();


        [HttpGet("califcaciones")]
        public List<Calificacion> get(int idMatricula)
        {
            return calificacionesDAO.seleccionar(idMatricula);
        }

        [HttpPost("califcacion")]
        public bool agregar([FromBody] Calificacion calificacion)
        {
            return calificacionesDAO.agregarCalificacion(calificacion);
        }

        [HttpDelete("califcacion")]
        public bool eliminar(int id)
        {
            return calificacionesDAO.eliminarCalificacion(id);
        }
    }
}
