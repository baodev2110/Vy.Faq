using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vy.Faq.Models;
using Microsoft.EntityFrameworkCore;
using Vy.Faq.Services;

namespace Vy.Faq
{
	public class Startup
	{
		private readonly IDatabaseInitialize _databaseInitialize;
		public Startup(IConfiguration configuration, IDatabaseInitialize databaseInitialize)
		{
			Configuration = configuration;
			_databaseInitialize = databaseInitialize;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			
			services.AddDbContext<VyContext>(opt =>
				opt.UseSqlServer(Configuration.GetConnectionString("VyFaq")));
			services.AddControllersWithViews();

			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "client-app/dist";
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "client-app";

				if (env.IsDevelopment())
				{
					spa.UseVueDevelopmentServer();
				}
			});

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				_databaseInitialize.Initialize(serviceScope.ServiceProvider.GetRequiredService<VyContext>());
			}

			
		}

	}
}
