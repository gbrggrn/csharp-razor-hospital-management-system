using Csharp3_A1.Models;
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
		}
	}
}
