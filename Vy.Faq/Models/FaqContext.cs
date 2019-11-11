using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vy.Faq.Models
{
	public class FaqContext : DbContext
	{
		public FaqContext(DbContextOptions<FaqContext> options)
			: base(options)
		{
		}

		public DbSet<Faq> FaqItems { get; set; }
	}
}
