using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoContactos.Utils
{
    public class PathHandler
    {
        private static readonly string fileName = "Local_Contacts.txt";
        private static readonly string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"Data\");
        private static readonly string _path = folder + fileName;

        public static string CreateDefaultPath()
        {
            if (File.Exists(_path)) 
                return _path;

            DirectoryInfo di = Directory.CreateDirectory(folder);
            FileStream fs = File.Create(_path);

            fs.Dispose();
            fs.Close();

            WriteDummyStuffOnFile();

            Console.WriteLine("Se ha auto-generado un fichero con texto de prueba");

            return _path;
        }

        private static void WriteDummyStuffOnFile()
        {
            string[] dummyStuff = { "Mike Salomon Iglesio",
                                "Javier San Isidoro Javier@gmail.com",
                                "Naima Miron Bernabeu",
                                "Paco Ignacio Ramon Paquito@gmail.com",
                                "Pedro Palomo Marron",
                                "Prueba1 Prueba1 Prueba1",
                                "Prueba2 Prueba2 Prueba2",
                                "Prueba3 Prueba3 Prueba3",
                                "Texto MasTexto AunMasTexto",
                                "Asdg Asdg Asdg Asdg@gmail.com"};
            try
            {
                File.WriteAllLines(_path, dummyStuff);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
