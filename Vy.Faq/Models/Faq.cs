using System.ComponentModel.DataAnnotations.Schema;

namespace Vy.Faq.Models
{
	[Table("Faqs")]

	public class Faq
	{
		public int Id { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public int Likes { get; set; }
		public int Dislikes { get; set; }
	}
}
