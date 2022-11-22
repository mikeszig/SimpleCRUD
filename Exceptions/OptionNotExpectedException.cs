namespace ListadoContactos.Exceptions
{

    [Serializable]
    public class OptionNotExpectedException : Exception
    {

        public OptionNotExpectedException()
            : base("Option number not expected. Please select between one of the options available") { }

        private OptionNotExpectedException(string message)
            : base(message) { }

        private OptionNotExpectedException(string message, Exception inner)
            : base(message, inner) { }

    }

}