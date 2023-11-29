using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class AsignaturaDAO
    {
        //Creamos un objeto de contexto de DB
        public ProyectoContext contexto = new ProyectoContext();

        //Método para seleccionar todos las materias
        public List<Asignatura> seleccionarTodas()
        {
            var asignatura = contexto.Asignaturas.ToList<Asignatura>();
            return asignatura;
        }

        //Método para seleccionar una asignatura en especifico.
        public Asignatura seleccionar(int id)
        {
            var asignatura = contexto.Asignaturas.Where(a => a.Id == id).FirstOrDefault();
            return asignatura;
        }

        //Método para insertar una nueva asignatura a la BD.
        public bool insertarAsignatura(int id, string nombre, int creditos, string profesor)
        {
            try
            {
                Asignatura asignatura = new Asignatura();
                asignatura.Id = id;
                asignatura.Nombre = nombre;
                asignatura.Creditos = creditos;
                asignatura.Profesor = profesor;

                contexto.Asignaturas.Add(asignatura);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para actualizar los datos de una materia en la bd
        public bool actualizar(int id, string nombre, int creditos, string profesor)
        {
            try
            {
                var asignatura = seleccionar(id);
                if (asignatura == null)
                {
                    return false;
                }
                else
                {
                    asignatura.Nombre = nombre;
                    asignatura.Creditos = creditos;
                    asignatura.Profesor= profesor;

                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
