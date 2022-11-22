using ListadoContactos.Model;

namespace ListadoContactos.Controller
{

    public interface IContactsHandler
    {

        void SaveContacts(List<ContactModel> contacts);
        void RemoveContacts(List<ContactModel> contacts);
        List<ContactModel> LoadContacts();

    }

}