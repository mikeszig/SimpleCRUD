using ListadoContactos.Exceptions;
using ListadoContactos.Model;
using System.Text.RegularExpressions;

namespace ListadoContactos.Utils
{

    public class Validator
    {

        public static bool ValidateEmail(string email)
        {
            if (email.Equals("Null") || email.Equals(null) || email.Equals("null"))
                return false;

            if (!email.EndsWith("@gmail.com"))
                return false;

            return true;
        }

        public static string ValidatePath(string path)
        {
            if(path == null)
            {
                Console.WriteLine("Variable '_path' can't be null");
                throw new InvalidOperationException();
            }

            if(!File.Exists(path))
            {
                Console.WriteLine("Path does not point to any file");
                throw new InvalidOperationException();
            }

            return path;
        }

        public static string Formatter(string line)
        {
            string lineFormatted = "";
            string[] items = line.Trim().Split(' ');

            foreach (var item in items)
                lineFormatted += item.FirstCharToUpper();

            return lineFormatted;
        }

        public static ContactModel ContactConverter(string line)
        {
            string contactNotConverted = Formatter(line);
            string[] items = Regex.Split(contactNotConverted, @"(?<!^)(?=[A-Z])");

            return items.Length switch
            {
                0 => throw new ItemsNumberInvalidException(),
                1 => throw new ItemsNumberInvalidException(),
                2 => new ContactModel(items[0], items[1]),
                3 => new ContactModel(items[0], items[1] + " " + items[2]),
                4 => new ContactModel(items[0], items[1] + " " + items[2], items[3]),
                5 => new ContactModel(items[0], items[1] + " " + items[2] + " " + items[3], items[4]),
                _ => throw new ItemsNumberInvalidException(),
            };
            throw new ItemsNumberInvalidException();
        }

    }

}