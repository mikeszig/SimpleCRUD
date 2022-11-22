using ListadoContactos.Utils;

namespace ListadoContactos.Model
{

    public class DataMemory : IContactsFileHandler
    {

        private List<ContactModel> _contacts;

        public DataMemory()
        {
            _contacts ??= new()
            {
                new ContactModel("Miguel", "Sanchez Ingles"),
                new ContactModel("Javier", "Sanchez Ingles", "javier@gmail.com"),
                new ContactModel("Naima", "Miron Bernabeu"),
                new ContactModel("Paco", "Ingles Ros", "paquito@gmail.com"),
            };
        }

        public List<ContactModel> LoadContacts() => _contacts;

        public void SaveContacts(List<ContactModel> contacts)
        {
            foreach (ContactModel contact in contacts)
            {
                if (!Validator.ValidateEmail(contact.Email))
                    contact.Email = null;
                _contacts.Add(contact);
            }
        }

        public void RemoveContacts(List<ContactModel> contacts)
        {
            foreach (ContactModel contact in contacts)
                _contacts.RemoveAll(x => x.NombreCompleto.Equals(contact.NombreCompleto));
        }

    }

}