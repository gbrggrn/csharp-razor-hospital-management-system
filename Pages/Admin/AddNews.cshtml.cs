using Csharp3_A1.Models;
using Csharp3_A1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Csharp3_A1.Pages.Admin
{
    public class AddNewsModel : PageModel
    {
        [BindProperty] 
        public NewsItem NewsItem { get; set; }

		private readonly NewsService _newsService;

		public AddNewsModel(NewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> OnPostAddSync()
        {
            await _newsService.AddAsync(NewsItem);
            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
