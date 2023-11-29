using Congreso.Models;
using Congreso.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace CongresoWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class PaticipanteController : ControllerBase
    {
        private ParticipanteDAO participanteDAO = new ParticipanteDAO();

        /**
         *EndPoint para obtener un participante especifico
         */
        [HttpGet("participante")]
        public Participante getAlumno(int id)
        {
            return participanteDAO.seleccionar(id);
        }

        /** 
          EndPoint para obtener todos los participantes
             */
        [HttpGet("participantes")]
        public ActionResult<List<Participante>> GetAsignaturas()
        {
            List<Participante> participantes = participanteDAO.seleccionarTodos();

            if (participantes == null || participantes.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron materias.
            }
            return participantes;
        }


        /**
         *EndPoint para insertar un participante
         */
        [HttpPost("participante")]
        public bool insertarAsignatura([FromBody] Participante participante)
        {
            return participanteDAO.insertar(participante.IdParticipantes, participante.Nombre, 
                participante.Apellidos,participante.Email, participante.Twitter, participante.Avatar);
        }
    }
}
