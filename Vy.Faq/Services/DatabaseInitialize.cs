using System.Collections.Generic;
using System.Linq;
using Vy.Faq.Models;

namespace Vy.Faq.Services
{
	public class DatabaseInitialize : IDatabaseInitialize
	{
		public void Initialize(VyContext context)
		{
			context.Database.EnsureCreated();
			if (!context.Faqs.ToList().Any())
			{
				var faqs = new List<Models.Faq>
				{
					new Models.Faq
					{
						Question = "Hvordan kjøper jeg billett?",
						Answer = "Du kan kjøpe billett fra vy.no"
					},
					new Models.Faq
					{
						Question = "Hvordan kjøper jeg periodebillett?",
						Answer = "Det enkleste for deg er å kjøpe periodebilletten i appen. Vi tilbyr også periodebillett for Ruter, Kolumbus og Skyss. Enkelte varianter selger vi kun i appen."
					}
				};

				foreach (var faq in faqs)
				{
					context.Faqs.Add(faq);
					context.SaveChanges();
				}
			}

		}

	}
}
