namespace ListadoContactos.Exceptions
{

    [Serializable]
    public class ItemsNumberInvalidException : Exception
    {

        public ItemsNumberInvalidException()
            : base("Number of items on Validator.ContactConverter invalid") { }

        private ItemsNumberInvalidException(string message)
            : base(message) { }

        private ItemsNumberInvalidException(string message, Exception inner)
            : base(message, inner) { }

    }

}