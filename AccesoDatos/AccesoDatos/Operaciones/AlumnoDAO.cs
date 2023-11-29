using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class AlumnoDAO
    {
        //Creamos un objeto de contexto de DB
        public ProyectoContext contexto = new ProyectoContext();

        //Método para seleccionar todos los alumnos
        public List<Alumno> seleccionarTodos()
        {
            var alumnos = contexto.Alumnos.ToList<Alumno>();
            return alumnos;
        }

        //Método para seleccionar un alumno en especifico.
        public Alumno seleccionar(int id)
        {
            var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();
            return alumno;
        }

        //Método para insertar un nuevo alumno a la BD.
        public bool insertar(string  dni, string nombre, string direccion, int edad, string email) 
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Dni = dni;
                alumno.Nombre = nombre;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;

                contexto.Alumnos.Add(alumno);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            { 
                return false;
            }
        }
        //Metodo para seleccionar a un alumno en base a su dni
        public Alumno seleccionarPorDni(string dni)
        {
            var alumno = contexto.Alumnos.Where(a => a.Dni == dni).FirstOrDefault();
            return alumno;
        }

        //Metodo para actualizar los datos de un alumno en la bd
        public bool actualizar(int id, string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                var alumno = seleccionar(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    alumno.Dni = dni;
                    alumno.Nombre = nombre;
                    alumno.Direccion = direccion;
                    alumno.Edad = edad;
                    alumno.Email = email;

                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para eliminar
        public bool eliminar(int id)
        {
            try
            {
                var alumno = seleccionar(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
        
    }
        }


        public List<AlumnoAsignatura>
            seleccionarAlumnosAsignaturas()
        {
            var query = from a in contexto.Alumnos
                        join m in contexto.Matriculas on a.Id
                    equals m.AlumnoId
                        join asig in contexto.Asignaturas on
                    m.AsignaturaId equals asig.Id
                        select new AlumnoAsignatura
                        {
                            NombreAlumno = a.Nombre,
                            NombreAsignatura = asig.Nombre
                        };
            return query.ToList();
        }
        public List<AlumnoProfesor> seleccionarAlumnosProfesor(string usuario)
        {
            var query = from a in contexto.Alumnos
                        join m in contexto.Matriculas on a.Id
                        equals m.AlumnoId
                        join asig in contexto.Asignaturas on
                        m.AsignaturaId equals asig.Id
                        where asig.Profesor == usuario
                        select new AlumnoProfesor
                        {
                            id = a.Id,
                            Dni = a.Dni,
                            Nombre = a.Nombre,
                            Direccion = a.Direccion,
                            Edad = a.Edad,
                            Email = a.Email,
                            Asignatura = asig.Nombre
                        };
            return query.ToList();
        }

        public bool insertarMatricula(string dni, string nombre, string direccion, int edad, string email, int id_asig)
        {
            try
            {
                //Verificar si el alumno ya existe
                var existe = seleccionarPorDni(dni);
                if (existe == null)
                {
                    insertar(dni, nombre, direccion, edad, email);
                    var insertado = seleccionarPorDni(dni);
                    Matricula m = new Matricula();
                    m.AlumnoId = insertado.Id;
                    m.AsignaturaId = id_asig;
                    // Guardamoslos cambios
                    contexto.Matriculas.Add(m);
                    contexto.SaveChanges();
                }
                else
                {
                    Matricula m = new Matricula();
                    m.AlumnoId = existe.Id;
                    m.AsignaturaId = id_asig;
                    // Guardamoslos cambios
                    contexto.Matriculas.Add(m);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarCalificacionesAlumno(int id)
        {
            try
            {
                var alumno = contexto.Alumnos.Where(m => m.Id == id).FirstOrDefault();

                if (alumno != null)
                {
                    //Recueperamos todas las matriculas del alumno
                    var matriculas = contexto.Matriculas.Where(m => m.AlumnoId == id);

            foreach (Matricula m in matriculas)
                    {
                        //recuperamos las calificaciones del alumno
                        var calificaciones = contexto.Calificacions.Where(c => c.MatriculaId == m.Id);
                        contexto.Calificacions.RemoveRange(calificaciones);
                    }
                    contexto.Matriculas.RemoveRange(matriculas);
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
        }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        }
    }
