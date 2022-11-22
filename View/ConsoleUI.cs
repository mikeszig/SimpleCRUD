using ListadoContactos.Controller;
using ListadoContactos.Exceptions;
using ListadoContactos.Model;
using ListadoContactos.Utils;
using System.Text.RegularExpressions;

namespace ListadoContactos.View
{

    public class ConsoleUI : IConsoleUI
    {
        private static ContactsHandler? _contactsHandler;
        private static List<ContactModel>? _listContacts;

        private static string? _memorySelected;
        private static string? _path;

        private const string _msg1 = "Para introducir los contactos sigue el siguiente formato:\n" +
                "Nombre Apellido1 Apellido2 <Email (Opcional)>\n" +
                "(Pulsa enter cuando hayas terminado de escribir los contactos)\n" +
                "Empieza a escribir a continuación.";
        private const string _msg2 = "¿Quieres mostrar los cambios efectuados? Escribe Y/N (si/no)";

        private static Regex _rgx;
        private const string _pattern = "^[^0-9()]+";

        public ConsoleUI()
        {
            _rgx = new Regex(_pattern);
        }

        public void Show()
        {
            StartUI();
        }

        private static void StartUI()
        {
            Console.WriteLine("Hola! Bienvenido a tu gestor de contactos favorito.");

            Console.WriteLine("A continuación se le abrirá el menú de opciones." +
                            "\nEscriba el número que pertenezca a la opción que desea:");

            Console.WriteLine("1. Cargar la lista de contactos." +
                            "\n2. Añadir uno o varios contactos nuevos." +
                            "\n3. Borrar uno o varios contactos registrados.");

            string option = Console.ReadLine().Trim();

            int[] options= new int[] { 1 ,2 ,3 };

            if (option.Equals("") || _rgx.IsMatch(option) || !options.Contains(Convert.ToInt32(option)))
                StartUI();

            LoadController(Convert.ToInt32(option));
        }

        private static void LoadController(int option)
        {
            _listContacts = new List<ContactModel>();

            Console.WriteLine("¿Quiere acceder a memoria(MEMORY) o fichero(FILE)?" +
                            "\nEscriba el datasource que desee consultar.");

            _memorySelected = Console.ReadLine().Trim().ToLower();
            string[] memoryOptions = new string[] { "memory", "file" };
            if (_memorySelected == null || !memoryOptions.Contains(_memorySelected))
            {
                Console.WriteLine("Escribe un acceso de memoria válido");
                LoadController(option);
                //throw new UnrecognizedMemoryAccessException();
            }

            if (_memorySelected.Equals("file"))
            {
                Console.WriteLine("Escibra la ruta de acceso completa.\n" +
                                    "Si no escribe ninguna ruta específica se usará la por defecto.");
                _path = Console.ReadLine();

                if (!CheckPath(_path))
                {
                    _path = PathHandler.CreateDefaultPath();
                    Console.WriteLine($"Usando el fichero por defecto que se encuentra en la ruta: {_path}\n");
                    //throw new UnrecognizedMemoryAccessException();
                }

                _contactsHandler = new(_path);

            } else
                _contactsHandler = new();

            switch (option)
            {
                case 1: LoadContactsUI(_contactsHandler); break;
                case 2: SaveContacts(_contactsHandler); break;
                case 3: RemoveContacts(_contactsHandler); break;
                default: throw new OptionNotExpectedException();
            }
        }

        private static bool CheckPath(string path)
        {
            if (path == null || path.Equals(""))
            {
                Console.WriteLine("Cargando fichero de pruebas...");
                return false;
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("El fichero al que intentas apuntar no existe.\n" +
                                    "En su defecto cargararemos el fichero de pruebas.");
                return false;
            }

            return true;
        }

        private static void  LoadContactsUI(ContactsHandler handler)
        {
            _listContacts = handler.LoadContacts();

            foreach (ContactModel contact in _listContacts)
                Console.WriteLine(contact);

            _listContacts.Clear();
        }

        private static void SaveContacts(ContactsHandler handler)
        {
            Console.WriteLine("Introduce la lista de contactos que quieras añadir a la fuente de datos.\n" + $"{_msg1}");
            string contactString = Console.ReadLine();
            ContactModel contactModel;

            while (!contactString.Equals(""))
            {
                contactModel = ContactStringToContactModel(contactString);
                _listContacts.Add(contactModel);
                contactString = Console.ReadLine();
            }

            handler.SaveContacts(_listContacts);

            _listContacts.Clear();

            Console.WriteLine($"{_msg2}");
            if (Console.ReadLine().Equals("Y"))
                LoadContactsUI(handler);
        }

        private static void RemoveContacts(ContactsHandler handler)
        {
            Console.WriteLine("Introduce la lista de contactos que quieras eliminar de la fuente de datos.\n" + $"{_msg1}");
            string contactString = Console.ReadLine();
            ContactModel contactModel;

            while (!contactString.Equals(""))
            {
                contactModel = ContactStringToContactModel(contactString);
                _listContacts.Add(contactModel);
                contactString = Console.ReadLine();
            }

            handler.RemoveContacts(_listContacts);

            _listContacts.Clear();

            Console.WriteLine($"{_msg2}");
            if (Console.ReadLine().Equals("Y"))
                LoadContactsUI(handler);
        }

        private static ContactModel ContactStringToContactModel(string contact)
        {
            return Validator.ContactConverter(contact);
        }

    }

}