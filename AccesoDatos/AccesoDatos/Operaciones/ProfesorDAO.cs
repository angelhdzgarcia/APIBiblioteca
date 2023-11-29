using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class ProfesorDAO
    {
        //Creamos un objeto de contexto de DB
        public ProyectoContext contexto = new ProyectoContext();

        //Método para seleccionar todos los profesores
        public List<Profesor> seleccionarTodos()
        {
            var profesor = contexto.Profesors.ToList<Profesor>();
            return profesor;
        }

        //Método para seleccionar un profesor en especifico.
        public Profesor seleccionar(string usuario)
        {
            var profesor = contexto.Profesors.Where(a => a.Usuario == usuario).FirstOrDefault();
            return profesor;
        }
        
        //Método para insertar un nuevo profesor a la BD.
        public bool insertarProfesor(string usuario, string pass, string nombre, string email)
        {
            try
            {
                Profesor profesor = new Profesor();
                profesor.Usuario = usuario;
                profesor.Pass = pass;
                profesor.Nombre = nombre;
                profesor.Email = email;

                contexto.Profesors.Add(profesor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para actualizar los datos de un profesor en la bd
        public bool actualizar(string usuario, string pass, string nombre, string email)
        {
            try
            {
                var profesor = seleccionar(usuario);
                if (profesor == null)
                {
                    return false;
                }
                else
                {
                    profesor.Pass = pass;
                    profesor.Nombre = nombre;
                    profesor.Email = email;

                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Profesor login (string  usuario, string password)
        {
            var prof = contexto.Profesors.Where(p => p.Usuario == usuario && p.Pass ==password).FirstOrDefault();

            return prof;
        }
    }
}
