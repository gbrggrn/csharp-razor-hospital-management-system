using Csharp3_A1.Models;
using Csharp3_A1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Csharp3_A1.Pages.Admin
{
    public class NewsManagementModel : PageModel
    {
        private readonly NewsService _newsService;
        public List<NewsItem> NewsItems { get; set; } = [];

		public NewsManagementModel(NewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task OnGetAsync()
        {
            NewsItems = await _newsService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _newsService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
