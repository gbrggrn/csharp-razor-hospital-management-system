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
					new NewsItem { Title = "HUEGHAOG", Content = "Iihaoehf aihefoah faoeu h oaue hfuaeh haeouh!", ImagePath = "~images/news/news_hospital_img1" });
				
				await context.SaveChangesAsync();
			}
		}
	}
}
