using Microsoft.EntityFrameworkCore;
using Csharp3_A1.Models;

namespace Csharp3_A1.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		//public DbSet<Patient> Patient { get; set; }
		//public DbSet<Appointment> Appointment { get; set; }
		public DbSet<NewsItem> NewsItems { get; set; }
	}
}
