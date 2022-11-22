using System.Diagnostics.CodeAnalysis;

namespace ListadoContactos.Model
{

	public class ContactModel
	{

		public ContactModel(string nombre, string apellidos)
		{
			Nombre = nombre;
			Apellidos = apellidos;
			NombreCompleto = $"{nombre} {apellidos}";
		}

		public ContactModel(string nombre, string apellidos, string email)
		{
			Nombre = nombre;
			Apellidos = apellidos;
			NombreCompleto = $"{nombre} {apellidos}";
			Email = email;
		}

		public string Nombre { get; set; } = "null";
		public string Apellidos { get; set; } = "null";
		public string NombreCompleto { get; set; } = "null";
		[AllowNull]
		public string Email { get; set; } = "null";

		public override string ToString() => $"{NombreCompleto} {Email}";

	}

}