using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Vy.Faq.Models;
using Vy.Faq.Services;

namespace Vy.Faq
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureServices(serviceCollection =>
					serviceCollection
						.AddScoped<IDatabaseInitialize, DatabaseInitialize>())
				.UseStartup<Startup>();
	}
}
