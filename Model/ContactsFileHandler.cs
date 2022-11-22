using ListadoContactos.Utils;

namespace ListadoContactos.Model
{

    public class ContactsFileHandler : IContactsFileHandler
    {

        private readonly string? _path = @"C:\Users\Miguel\Desktop\Ejercicios\DummyFolder\DummyFile.txt";

        public ContactsFileHandler(string path)
        {
            _path = Validator.ValidatePath(path);
        }

        public void RemoveContacts(List<ContactModel> contacts)
        {
            List<ContactModel> contactsOriginal = new();
            contactsOriginal = LoadContacts();

            foreach (ContactModel contact in contacts)
                contactsOriginal.RemoveAll(x => x.NombreCompleto.Equals(contact.NombreCompleto));

            File.WriteAllText(_path, string.Empty);
            
            SaveContacts(contactsOriginal);
        }

        public List<ContactModel> LoadContacts()
        {
            string[] lines = File.ReadAllLines(_path);
            List<ContactModel> contacts = new();

            foreach (string line in lines)
                contacts.Add(Validator.ContactConverter(line));

            return contacts;
        }

        public void SaveContacts(List<ContactModel> contacts)
        {
            using StreamWriter file = new(_path, append: true);
            
            foreach (ContactModel contact in contacts)
            {
                if (!Validator.ValidateEmail(contact.Email))
                    contact.Email = null;
                file.WriteLine(contact.ToString());
            }
        }

    }

}