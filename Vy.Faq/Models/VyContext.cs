using Microsoft.EntityFrameworkCore;

namespace Vy.Faq.Models
{
	public class VyContext : DbContext
	{
		public VyContext(DbContextOptions<VyContext> options) : base(options)
		{

		}

		public DbSet<Faq> Faqs { get; set; }
		public DbSet<QuestionForm> QuestionForms { get; set; }
	}
}
