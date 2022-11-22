using ListadoContactos.Model;
using System.Diagnostics.CodeAnalysis;

namespace ListadoContactos.Controller
{

    public class ContactsHandler : IContactsHandler
    {

        private readonly DataMemory? _memory;
        private readonly ContactsFileHandler? _contactsFileHandler;

        public ContactsHandler(string path)
        {
            _contactsFileHandler = new(path);
            LoadState = State.FILE;
        }

        public ContactsHandler()
        {
            _memory = new();
            LoadState = State.MEMORY;
        }

        public enum State
        {
            MEMORY, FILE
        }

        public void RemoveContacts(List<ContactModel> contacts)
        {
            if (LoadState.Equals(null))
                throw new InvalidOperationException();

            if (LoadState == State.MEMORY)
                _memory.RemoveContacts(contacts);
            else
                _contactsFileHandler.RemoveContacts(contacts);
        }

        public void SaveContacts(List<ContactModel> contacts)
        {
            if (LoadState.Equals(null))
                throw new InvalidOperationException();

            if (LoadState == State.MEMORY)
                _memory.SaveContacts(contacts);
            else
                _contactsFileHandler.SaveContacts(contacts);
        }

        public List<ContactModel> LoadContacts()
        {
            if (LoadState.Equals(null))
                throw new InvalidOperationException();

            if (LoadState == State.MEMORY)
                return _memory.LoadContacts();
            else
                return _contactsFileHandler.LoadContacts();
        }

        private State LoadState { set; get; }
        
    }

}