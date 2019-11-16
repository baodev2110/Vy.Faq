using Vy.Faq.Models;

namespace Vy.Faq.Services
{
	public interface IDatabaseInitialize
	{
		void Initialize(VyContext vyContext);
	}
}
