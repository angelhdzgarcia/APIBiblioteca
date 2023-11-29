using Congreso.Context;
using Congreso.Models;
using System.Linq;

namespace Congreso.Operaciones
{
    public class ConferenciaDAO
    {
        //Creamos un objeto de contexto de DB
        public CongresoContext contexto = new CongresoContext();

        //Método para seleccionar todas las conferencias
        public List<Conferencia> seleccionarTodos()
        {
            var conferencias = contexto.Conferencias.ToList<Conferencia>();
            return conferencias;
        }
    }
}
