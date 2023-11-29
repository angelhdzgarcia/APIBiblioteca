using Congreso.Context;
using Congreso.Models;

namespace Congreso.Operaciones
{
    public class ParticipanteDAO
    {
        //Creamos un objeto de contexto de DB
        public CongresoContext contexto = new CongresoContext();

        //Método para seleccionar todos los participantes
        public List<Participante> seleccionarTodos()
        {
            var participantes = contexto.Participantes.ToList<Participante>();
            return participantes;
        }

        //Método para seleccionar un alumno en especifico.
        public Participante seleccionar(int id)
        {
            var participante = contexto.Participantes.Where(a => a.IdParticipantes == id).FirstOrDefault();
            return participante;
        }

        //Método para insertar un nuevo alumno a la BD.
        public bool insertar(int idParticipantes, string nombre, string apellidos, string email, string twitter, int avatar)
        {
            try
            {
                Participante participante = new Participante();
                participante.IdParticipantes = idParticipantes;
                participante.Nombre = nombre;
                participante.Apellidos = apellidos;
                participante.Email = email;
                participante.Twitter = twitter;
                participante.Avatar = avatar;

                contexto.Participantes.Add(participante);
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
