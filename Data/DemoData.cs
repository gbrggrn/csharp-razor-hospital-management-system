using Csharp3_A1.Models;
using Csharp3_A1.Services;
using System.Reflection;

namespace Csharp3_A1.Data
{
	public class DemoData
	{
		public static async Task InitializeAsync(IServiceProvider services)
		{
			using var scope = services.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			if (!context.NewsItems.Any())
			{
				context.NewsItems.AddRange(
					new NewsItem { Title = "Rabies finally cured", Content = "A patient has, for the first time, made a full recovery from rabies infection", ImagePath = "images/news/news_hospital_img1.jpg" },
					new NewsItem { Title = "Screen induced sadness prevalent among teachers", Content = "Universities need to find more free time for teachers, research finds", ImagePath = "images/news/news_hospital_img2.jpg" },
					new NewsItem { Title = "New fake it until you make it-program successful in recruiting new doctors", Content = "Who needs education anyway?", ImagePath = "images/news/news_hospital_img3.jpg" },
					new NewsItem { Title = "Involountary handclapping connected to chronic fatigue", Content = "Some people keep clapping their hands, and it is making them tired", ImagePath = "images/news/news_hospital_img4.jpg" },
					new NewsItem { Title = "Handsome doctors found to cure patients faster", Content = "Good news for patients - more handsome doctors will be selected through the fake it until you make it-program", ImagePath = "images/news/news_hospital_img5.jpg" }
					);
				
				await context.SaveChangesAsync();
			}

			if (!context.Patients.Any())
			{
				context.Patients.AddRange(
					new Patient { Name = "James Harrison", DateOfBirth = new DateTime(1950, 5, 10) },
					new Patient { Name = "Emily Carter", DateOfBirth = new DateTime(1991, 10, 15) },
					new Patient { Name = "William Brooks", DateOfBirth = new DateTime(1975, 8, 22) },
					new Patient { Name = "Olivia Bennett", DateOfBirth = new DateTime(2001, 2, 18) },
					new Patient { Name = "Henry Foster", DateOfBirth = new DateTime(1994, 11, 2) }
				);
				
				await context.SaveChangesAsync();

				var patients = context.Patients.ToList();

				context.MedicalHistories.AddRange(
					new MedicalHistory
					{
						Patient = patients[0],
						PatientId = patients[0].Id,
						DateOfVisit = new DateTime(2022, 1, 22),
						Reason = "Broken leg",
						Notes = "Plastered"
					},
					new MedicalHistory 
					{
						Patient = patients[1],
						PatientId = patients[1].Id,
						DateOfVisit = new DateTime(2020, 2, 24),
						Reason = "Common Cold",
						Notes = "Prescribed ibuprofen"
					},
					new MedicalHistory
					{
						Patient = patients[2],
						PatientId = patients[2].Id,
						DateOfVisit = new DateTime(2021, 9, 14),
						Reason = "Routine Checkup",
						Notes = "All fine"
					},
					new MedicalHistory
					{
						Patient = patients[3],
						PatientId= patients[3].Id,
						DateOfVisit = new DateTime(1999, 4, 4),
						Reason = "Depression",
						Notes = "Pat on the back"
					},
					new MedicalHistory
					{
						Patient = patients[4],
						PatientId = patients[4].Id,
						DateOfVisit = new DateTime(2006, 7, 8),
						Reason = "Sore throat",
						Notes = "Can not speak"
					}
					);

				await context.SaveChangesAsync();
			}
		}
	}
}
