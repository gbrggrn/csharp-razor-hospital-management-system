using Microsoft.EntityFrameworkCore;
using Csharp3_A1.Models;

namespace Csharp3_A1.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<NewsItem> NewsItems { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<MedicalHistory> MedicalHistories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Staff> Staff {  get; set; }
	}
}
