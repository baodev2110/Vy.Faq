using Microsoft.EntityFrameworkCore;

namespace Vy.Faq.Models
{
	public class FaqContext : DbContext
	{
		public FaqContext(DbContextOptions<FaqContext> options)
			: base(options)
		{
			this.Database.EnsureCreated();
		}

		public DbSet<Faq> FaqItems { get; set; }
	}
}
