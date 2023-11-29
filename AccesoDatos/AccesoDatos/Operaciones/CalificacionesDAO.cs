using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class CalificacionesDAO
    {
        ProyectoContext contexto = new ProyectoContext();

        //Metodo para consultar el listado de calificaciones de un alumno.
        public List<Calificacion> seleccionar(int id)
        {
            var calificaciones = contexto.Calificacions.Where(c => c.Matricula.Id == id).ToList();

            return calificaciones;
        }

        //Metodo para agregar una nueva calificacion
        public bool agregarCalificacion(Calificacion calificacion)
        {
            try
            {
                contexto.Calificacions.Add(calificacion);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para 
        public bool eliminarCalificacion(int id)
        {
            var calificacion =contexto.Calificacions.Where(c => c.Matricula.Id ==id).FirstOrDefault();
            try
            {
                if(calificacion != null)
                {
                    contexto.Calificacions.Remove(calificacion);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }               
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
