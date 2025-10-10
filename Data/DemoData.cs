using Csharp3_A1.Models;
using Csharp3_A1.Services;
using SQLitePCL;
using System.Reflection;

namespace Csharp3_A1.Data
{
	public class DemoData
	{
		public static async Task InitializeAsync(IServiceProvider services)
		{
			using var scope = services.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			//Seed news items
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

			//Seed staff
			if (!context.Staff.Any())
			{
				context.Staff.AddRange(
					new Staff { Name = "Doctor Scott" },
					new Staff { Name = "Doctor Smith" },
					new Staff { Name = "Doctor French" },
					new Staff { Name = "Doctor Breakfast" },
					new Staff { Name = "Doctor Brown" }
					);

				await context.SaveChangesAsync();
			}

			//Seed patients
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
			}

			//Seed medical histories
			if (!context.MedicalHistories.Any())
			{
				var patients = context.Patients.ToList();
				var staff = context.Staff.ToList();

				context.MedicalHistories.AddRange(
					new MedicalHistory
					{
						Patient = patients[0],
						PatientId = patients[0].Id,
						StaffId = staff[0].Id,
						DateOfVisit = new DateTime(2022, 1, 22),
						Reason = "Broken leg",
						Notes = "Plastered"
					},
					new MedicalHistory
					{
						Patient = patients[1],
						PatientId = patients[1].Id,
						StaffId = staff[1].Id,
						DateOfVisit = new DateTime(2020, 2, 24),
						Reason = "Common Cold",
						Notes = "Prescribed ibuprofen"
					},
					new MedicalHistory
					{
						Patient = patients[2],
						PatientId = patients[2].Id,
						StaffId = staff[2].Id,
						DateOfVisit = new DateTime(2021, 9, 14),
						Reason = "Routine Checkup",
						Notes = "All fine"
					},
					new MedicalHistory
					{
						Patient = patients[3],
						PatientId = patients[3].Id,
						StaffId = staff[3].Id,
						DateOfVisit = new DateTime(1999, 4, 4),
						Reason = "Depression",
						Notes = "Pat on the back"
					},
					new MedicalHistory
					{
						Patient = patients[4],
						PatientId = patients[4].Id,
						StaffId = staff[4].Id,
						DateOfVisit = new DateTime(2006, 7, 8),
						Reason = "Sore throat",
						Notes = "Can not speak"
					}
					);

				await context.SaveChangesAsync();
			}
			
			//Seed users - patients & doctors
			if (!context.Users.Any())
			{
				var patients = context.Patients.ToList();
				var doctors = context.Staff.ToList();

				context.Users.AddRange(
					//Patients
					new User { Username = "james", Password = "123", Role = "Patient", PatientId = patients[0].Id },
					new User { Username = "emily", Password = "123", Role = "Patient", PatientId = patients[1].Id },
					new User { Username = "william", Password = "123", Role = "Patient", PatientId = patients[2].Id },
					new User { Username = "olivia", Password = "123", Role = "Patient", PatientId = patients[3].Id },
					new User { Username = "henry", Password = "123", Role = "Patient", PatientId = patients[4].Id },
					
					//Doctors
					new User { Username = "drscott", Password = "123", Role = "Staff", StaffId = doctors[0].Id },
					new User { Username = "drsmith", Password = "123", Role = "Staff", StaffId = doctors[1].Id },
					new User { Username = "drfrench", Password = "123", Role = "Staff", StaffId = doctors[2].Id },
					new User { Username = "drbreakfast", Password = "123", Role = "Staff", StaffId = doctors[3].Id },
					new User { Username = "drbrown", Password = "123", Role = "Staff", StaffId = doctors[4].Id }
					);
			}

			//Seed appointments
			if (!context.Appointments.Any())
			{
				var patients = context.Patients.ToList();
				var doctors = context.Staff.ToList();

				context.Appointments.AddRange(
					new Appointment
					{
						DateOfAppointment = DateTime.Now.AddDays(2),
						PatientId = patients[0].Id,
						StaffId = doctors[0].Id,
						Reason = "Routine checkup"
					},
					new Appointment
					{
						DateOfAppointment = DateTime.Now.AddDays(12),
						PatientId = patients[1].Id,
						StaffId = doctors[1].Id,
						Reason = "Broken leg"
					},
					new Appointment
					{
						DateOfAppointment = DateTime.Now.AddDays(4),
						PatientId = patients[2].Id,
						StaffId = doctors[2].Id,
						Reason = "Sadness"
					},
					new Appointment
					{
						DateOfAppointment = DateTime.Now.AddDays(6),
						PatientId = patients[3].Id,
						StaffId = doctors[3].Id,
						Reason = "Funny bones"
					},
					new Appointment
					{
						DateOfAppointment = DateTime.Now.AddDays(5),
						PatientId = patients[4].Id,
						StaffId = doctors[4].Id,
						Reason = "Common cold"
					}
					);

				await context.SaveChangesAsync();
			}
		}
	}
}
