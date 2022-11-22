using ListadoContactos.View;

namespace MVC
{
    public class Program
    {
        public static void Main(String[] args)
        {
            ConsoleUI console = new();
            console.Show();
        }
    }
}

/**
 *   TO-DO
 *   
 *   Milestone:
 *   1. Listar contactos
 *   2. Añadir nuevos contactos
 *   3. Borrar contactos existentes
 *   4. Cargar contactos desde un fichero
 *   5. Guardar contactos en un fichero
 *   
 *   Workflow:
 *   1. La aplicación carga los contactos de un fichero
 *   2. El usuario puede realizar cambios en la lista de contactos
 *   3. Dichos cambios pueden ser guardados o no. (Y/N)
 *   
 *   Capa AD (Modelo):
 *   1. Dos interfaces (IContactModel y IContactsFileHandler)
 *   1.1. IContactModel: Define los miembros de un Contacto
 *   1.2. IContactsFileHandler: Define los métodos de guardar y cargar contactos en fichero
 *   
 *   Capa Aplicación (Controlador):
 *   2. Una interfaz IContactsHandler
 *   2.1. IContactsHandler: Métodos para tratar con la LISTA de contactos
 *   
 *   Capa Presentación (Vista):
 *   3. Una interfaz IConsoleUI
 *   3.1. IConsoleUI: Métodos para mostrar la lista de contactos por consola.
 *   Ádemas incluye para captar el input del usuario.
 *   
**/