using ExamenBiblioteca.Context;
using ExamenBiblioteca.Models;

namespace ExamenBiblioteca.Operaciones
{
    public class AutorDAO
    {
        //Creamos un objeto de contexto de DB
        public LibreriaContext contexto = new LibreriaContext();

        //Método para seleccionar todos los libros
        public List<Autor> seleccionarTodos()
        {
            var autores = contexto.Autors.ToList<Autor>();
            return autores;
        }

        //Método para insertar un nuevo autor en la BD.
        public bool insertar(int id, string nombre)
        {
            try
            {
                Autor autor = new Autor();
                autor.Id = id;
                autor.Nombre = nombre;
                
                contexto.Autors.Add(autor);
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
