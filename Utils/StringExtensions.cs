namespace ListadoContactos.Utils
{

    public static class StringExtensions
    {

        public static string FirstCharToUpper(this string input) =>
            string.Concat(input[0].ToString().ToUpper(), input.ToLower().AsSpan(1));

    }

}