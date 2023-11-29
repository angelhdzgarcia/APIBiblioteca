using Congreso.Models;
using Congreso.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CongresoWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ConferenciasController : ControllerBase
    {
        private ConferenciaDAO conferenciaDAO = new ConferenciaDAO();
        /** 
          EndPoint para obtener todos los participantes
             */
        [HttpGet("conferencias")]
        public ActionResult<List<Conferencia>> GetAsignaturas()
        {
            List<Conferencia> conferencias = conferenciaDAO.seleccionarTodos();

            if (conferencias == null ||conferencias.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron materias.
            }
            return conferencias;
        }
    }
}
