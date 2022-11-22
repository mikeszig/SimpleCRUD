namespace ListadoContactos.Exceptions
{

    [Serializable]
    public class UnrecognizedMemoryAccessException : Exception
    {

        public UnrecognizedMemoryAccessException()
            : base("Memory access location unrecognized. Select between MEMORY or FILE") { }

        private UnrecognizedMemoryAccessException(string message)
            : base(message) { }

        private UnrecognizedMemoryAccessException(string message, Exception inner)
            : base(message, inner) { }

    }

}
