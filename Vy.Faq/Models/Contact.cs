using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vy.Faq.Models
{
	[Table("Contacts")]

	public class Contact
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
