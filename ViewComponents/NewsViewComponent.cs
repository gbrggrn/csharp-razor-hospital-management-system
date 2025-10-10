using Csharp3_A1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharp3_A1.ViewComponents
{
	public class NewsViewComponent : ViewComponent
	{
		private readonly NewsService _newsService;

		public NewsViewComponent(NewsService newsService)
		{
			_newsService = newsService;
		}

		public async Task<IViewComponentResult> InvokeAsync(int? maxItems = null)
		{
			var news = await _newsService.GetAllAsync();
			if (maxItems.HasValue)
			{
				news = news.Take(maxItems.Value).ToList();
			}

			return View(news);
		}
	}
}